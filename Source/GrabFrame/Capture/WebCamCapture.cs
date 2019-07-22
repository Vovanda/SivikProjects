using DirectShowHelper;
using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace GrabFrame
{
  internal class WebCamCapture : IDisposable
  {   
    public WebCamCapture(IntPtr handle, int width, int height)
    {
      Handle = handle;
      Width = width;
      Height = height;
      _grayscaleCB = new GrayScaleSGCallBack();
    }

    public void Dispose()
    {
      CloseInterfaces();
      GC.SuppressFinalize(this);
    }

    public void Start()
    {
      IsRunning = true;
      mediaControl?.Run();
    }

    public void Stop()
    {
      mediaControl?.Stop();
      IsRunning = false;
    }

    public Bitmap GetBitmap()
    {
      Bitmap bitmapImage = null;
      scan = _grayscaleCB.GetScan();
      if (scan != IntPtr.Zero)
      {
        bitmapImage = new Bitmap(VideoWidth, VideoHeight, _stride, PixelFormat.Format24bppRgb, scan);
        bitmapImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
      }
      Marshal.FreeCoTaskMem(scan);
      scan = IntPtr.Zero;

      return bitmapImage;
    }

    public int VideoWidth { get; private set; }

    public int VideoHeight { get; private set; }

    public double FrameRate => IsRunning ? _grayscaleCB.FrameRate : 0;
    
    public bool IsRunning { get; set; } = false;
       
    public IntPtr Handle {
      get => _handle;
      set
      {
        _handle = value;
        ((IVideoWindow)filterGraph?.Object)?.put_Owner(_handle);
      }
    }

    public void SetCanvasSize(Size size) => SetCanvasSize(size.Width, size.Height);

    public void SetCanvasSize(int _width, int _height)
    {
      Width = _width;
      Height = _height;
      if (VideoWidth > 0 && VideoHeight > 0)
      {
        float x_scale = (float)Width / VideoWidth;
        float y_scale = (float)Height / VideoHeight;

        int width = Width;
        int height = Height;

        if (x_scale < y_scale)
        {
          height = width * VideoHeight / VideoWidth;
        }
        else if (x_scale > y_scale)
        {
          width = height * VideoWidth / VideoHeight;
        }

        int left = (Width - width) / 2;
        int top = (Height - height) / 2;
        
        ((IVideoWindow)filterGraph?.Object)?.SetWindowPosition(left, top, width, height);
      }
    }
    
    public void SetCurentDevice(DsDevice device)
    {
      CloseInterfaces();
      BuildGraph(device);
      Start();
    }

    private int Width { get; set; }

    private int Height { get; set; }

    private void BuildGraph(DsDevice device)
    {
      /*  
       * [VSource] -- [AVIDec] -- [SampleGraber] -- [Colour] -- [VRender]
       */

      filterGraph = (DShowObject<IFilterGraph2>)new FilterGraph();
      mediaControl = (IMediaControl)filterGraph.Object;
      var disposableObjects = new List<IDisposable>();
      try
      {
        var filters = new List<object>();
        var pBuilder = (DShowObject<ICaptureGraphBuilder2>)new CaptureGraphBuilder2();
        disposableObjects.Add(pBuilder);
        int hr = pBuilder.Object.SetFiltergraph(filterGraph.Object);
        DSHelper.CheckHR(hr);

        var videoSourceFilter = DSHelper.GetVideoSourceBaseFilter(device);
        var videoSource = new DShowObject<IBaseFilter>(videoSourceFilter);
        var aviDec = (DShowObject<IBaseFilter>)new AVIDec();
        var colour = (DShowObject<IBaseFilter>)new Colour();

        var sampleGrabber = (ISampleGrabber)new SampleGrabber();
        ConfigureSampleGrabber(sampleGrabber, _grayscaleCB);

        var grabber = new DShowObject<IBaseFilter>((IBaseFilter)sampleGrabber);
        var render = (DShowObject<IBaseFilter>)new VideoRenderer();

        disposableObjects.AddRange(new[] { videoSource, aviDec, colour, grabber, render });
        filterGraph.Object.AddFilters(videoSource, aviDec, colour, grabber, render);

        /* Add a copy-filter, e.g. the ColorSpaceConverter.          
         * Otherwise the samples will be allocated by the renderer
         * in video memory and reading off from video mem can be slow
         * (orders of magnitute slower than reading from system mem).
         */
        filterGraph.Object.ConnectDirect(videoSource, aviDec, 0, 0)
          .Next(grabber, 0, 0).Next(colour, 0, 0).Next(render, 0, 0);

        SaveSizeInfo(sampleGrabber);

        IVideoWindow vw = (IVideoWindow)filterGraph.Object;
        
        vw.put_Owner(_handle);
        vw.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings | WindowStyle.ClipChildren);
        SetCanvasSize(Width, Height);

        pBuilder.Object.RenderStream(PinCategory.Capture, MediaType.Video, videoSource, null, render.Object);
        
      }
      finally
      {
        foreach (var obj in disposableObjects)
        {
          obj.Dispose();
        }
      }
    }
    
    private void SaveSizeInfo(ISampleGrabber sampGrabber)
    {
      int hr;

      // Get the media type from the SampleGrabber
      AMMediaType media = new AMMediaType();
      hr = sampGrabber.GetConnectedMediaType(media);
      DsError.ThrowExceptionForHR(hr);

      if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero))
      {
        throw new NotSupportedException("Unknown Grabber Media Format");
      }

      // Grab the size info
      VideoInfoHeader videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
      VideoWidth = videoInfoHeader.BmiHeader.Width;
      VideoHeight = videoInfoHeader.BmiHeader.Height;
      _stride = VideoWidth * (videoInfoHeader.BmiHeader.BitCount / 8);

      DsUtils.FreeAMMediaType(media);
      media = null;
    }

    private void ConfigureSampleGrabber(ISampleGrabber sampGrabber, ISampleGrabberCB pCallBack)
    {
      var media = new AMMediaType
      {
        majorType = MediaType.Video,
        subType = MediaSubType.RGB24,
        formatType = FormatType.VideoInfo
      };

      int hr = sampGrabber.SetMediaType(media);
      DSHelper.CheckHR(hr);

      DsUtils.FreeAMMediaType(media);
      media = null;

      hr = sampGrabber.SetCallback(pCallBack, 1);
      DsError.ThrowExceptionForHR(hr);
    }
        
    private void CloseInterfaces()
    {
      try
      {
        if (mediaControl != null)
        {
          int hr = mediaControl.Stop();
          DSHelper.CheckHR(hr);
          IsRunning = false;
        }
        if (filterGraph != null)
        {
          filterGraph.Dispose();
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
    }

    public ManualResetEvent m_PictureReady = new ManualResetEvent(false);

    private DShowObject<IFilterGraph2> filterGraph;
    private IMediaControl mediaControl;
    private int _stride;
    private IntPtr scan = IntPtr.Zero;
    private IntPtr _handle = IntPtr.Zero;
    private readonly GrayScaleSGCallBack _grayscaleCB;    
  }
}