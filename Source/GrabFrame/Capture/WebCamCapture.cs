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

    public static readonly string NameOfNoneDevice = "(None)";

    [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
    private static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);

    public WebCamCapture(IntPtr handle, int width, int height)
    {
      Handle = handle;
      Width = width;
      Height = height;
      _dsDevices = DSHelper.GetDevicesName()
        .Zip(DSHelper.GetDevices(), (name, divice) => (name, divice))
        .ToDictionary(x => x.name, x => x.divice);
      _grayscaleCB = new GrayScaleSGCallBack();
    }

    public void Dispose()
    {
      CloseInterfaces();
      GC.SuppressFinalize(this);
    }

    public void Start()
    {
      CloseInterfaces();
      if (CurrentDeviceIsActive && Handle != IntPtr.Zero)
      {
        BuildGraph();
        mediaControl.Run();
      }
    }

    public Bitmap GetBitmap()
    {
      Bitmap bitmapImage = null;
      scan = _grayscaleCB.GetScan();
      if (scan != IntPtr.Zero)
      {
        bitmapImage = new Bitmap(m_videoWidth, m_videoHeight, m_stride, PixelFormat.Format24bppRgb, scan);
        bitmapImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
      }
      Marshal.FreeCoTaskMem(scan);
      scan = IntPtr.Zero;

      return bitmapImage;
    }

    public double FrameRate => _grayscaleCB.FrameRate;

    public string CurentDevice { get; private set; } = NameOfNoneDevice;

    public bool IsRunning { get; set; } = false;

    public string[] GetDevicesNames() => _dsDevices.Keys.Append(NameOfNoneDevice).ToArray();

    public bool CurrentDeviceIsActive => DeviceIsExist(CurentDevice);

    public IntPtr Handle { get; set; }

    public void SetCanvasSize(int width, int height)
    {
      Width = width;
      Height = height;
      ((IVideoWindow)filterGraph?.Object)?.SetWindowPosition(0, 0, Width, Height);
    }

    public void SetCanvasSize(Size size) => SetCanvasSize(size.Width, size.Height);

    public bool SetCurentDevice(string deviceName)
    {
      bool success = (DeviceIsExist(deviceName) || deviceName == NameOfNoneDevice) && deviceName != CurentDevice;

      if (success)
      {
        CurentDevice = deviceName;
        Start();
      }
      return success;
    }

    private int Width { get; set; }

    private int Height { get; set; }

   


    private void BuildGraph()
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


        var videoSource = new DShowObject<IBaseFilter>(GetVideoSourceFilter());
        var aviDec = (DShowObject<IBaseFilter>)new AVIDec();
        var colour = (DShowObject<IBaseFilter>)new Colour();

        var sampleGrabber = (ISampleGrabber)new SampleGrabber();
        ConfigureSampleGrabber(sampleGrabber, _grayscaleCB);

        var grabber = new DShowObject<IBaseFilter>((IBaseFilter)sampleGrabber);
        var render = (DShowObject<IBaseFilter>)new VideoRenderer();

        disposableObjects.AddRange(new[] { videoSource, aviDec, colour, grabber, render});
        filterGraph.Object.AddFilters(videoSource, aviDec, colour, grabber, render);

        /* Add a copy-filter, e.g. the ColorSpaceConverter.          
         * Otherwise the samples will be allocated by the renderer
         * in video memory and reading off from video mem can be slow
         * (orders of magnitute slower than reading from system mem).
         */
        filterGraph.Object.ConnectDirect(videoSource, aviDec, 0, 0)
          .Next(grabber, 0, 0).Next(colour, 0, 0).Next(render, 0, 0);

        IVideoWindow vw = (IVideoWindow)filterGraph.Object;
        vw.put_Owner(Handle);
        vw.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings | WindowStyle.ClipChildren);
        vw.SetWindowPosition(0, 0, Width, Height);

        pBuilder.Object.RenderStream(PinCategory.Capture, MediaType.Video, videoSource, null, render.Object);
        SaveSizeInfo(sampleGrabber);
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
      m_videoWidth = videoInfoHeader.BmiHeader.Width;
      m_videoHeight = videoInfoHeader.BmiHeader.Height;
      m_stride = m_videoWidth * (videoInfoHeader.BmiHeader.BitCount / 8);

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





    private IBaseFilter GetVideoSourceFilter() => CurrentDeviceIsActive ? DSHelper.GetVideoSourceBaseFilter(_dsDevices[CurentDevice]) : null;

    private bool DeviceIsExist(string deviceName) => !string.IsNullOrEmpty(deviceName) && (_dsDevices.ContainsKey(deviceName));

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
    private int m_videoWidth;
    private int m_videoHeight;
    private int m_stride;
    private IntPtr scan = IntPtr.Zero;
    private readonly GrayScaleSGCallBack _grayscaleCB;
    private readonly Dictionary<string, DsDevice> _dsDevices;
  }
}