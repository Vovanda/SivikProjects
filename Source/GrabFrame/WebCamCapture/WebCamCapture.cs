using DirectShowHelper;
using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace GrabFrame
{
  internal class WebCamCapture : IDisposable
  {

    public static readonly string NameOfNoneDevice = "(None)";

    public WebCamCapture(IntPtr handle, int width, int height)
    {
      Handle = handle;
      Width = width;
      Height = height;
      _dsDevices = DSHelper.GetDevicesName()
        .Zip(DSHelper.GetDevices(), (name, divice) => (name, divice))
        .ToDictionary(x => x.name, x => x.divice);
    }

    public void Dispose()
    {
      CloseInterfaces();
      GC.SuppressFinalize(this);
    }

    //private SampleGrabberCBFacade graberCB;

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

    public void Start()
    {
      CloseInterfaces();
      if (CurrentDeviceIsActive && Handle != IntPtr.Zero)
      {
        BuildGraph();
        mediaControl.Run();
      }
    }

    private void BuildGraph()
    {
      /*                         [AVIDec] -- [Colour] -- [SampleGraber]
       *                        /
       * [VSource] -- [Smart Tee] -- [AVIDec] -- [Colour] -- [VRender]
       * 
       */
   
        filterGraph = (DShowObject<IFilterGraph2>)new FilterGraph();
        mediaControl = (IMediaControl)filterGraph.Object;
        var disposableObjects = new List<IDisposable>();
        try {
          var filters = new List<object>();
          var pBuilder = (DShowObject<ICaptureGraphBuilder2>)new CaptureGraphBuilder2();
          disposableObjects.Add(pBuilder);
          int hr = pBuilder.Object.SetFiltergraph(filterGraph.Object);
          DSHelper.CheckHR(hr);

          var videoSource = new DShowObject<IBaseFilter>(GetVideoSourceFilter());
          var smartTee = (DShowObject<IBaseFilter>)new SmartTee();
          disposableObjects.AddRange(new[] { videoSource, smartTee });
          filterGraph.Object.AddFilters(videoSource, smartTee);

          var aviDec1 = (DShowObject<IBaseFilter>)new AVIDec();
          var colour1 = (DShowObject<IBaseFilter>)new Colour();
          var grabber = (DShowObject<IBaseFilter>)new SampleGrabber();
          disposableObjects.AddRange(new[] { aviDec1, colour1, grabber });
          var sampleGrabber = (ISampleGrabber)grabber.Object;
          filterGraph.Object.AddFilters(aviDec1.Object, colour1.Object, grabber.Object);

          var aviDec2 = (DShowObject<IBaseFilter>)new AVIDec();
          var colour2 = (DShowObject<IBaseFilter>)new Colour();
          var render = (DShowObject<IBaseFilter>)new VideoRenderer();
          disposableObjects.AddRange(new[] { aviDec2, colour2, render });
          filterGraph.Object.AddFilters(aviDec2.Object, colour2.Object, render.Object);

          filterGraph.Object.ConnectDirect(videoSource, smartTee, 0, 0);
          filterGraph.Object.ConnectDirect(smartTee, aviDec1, 0, 0).Next(colour1, 0, 0).Next(grabber, 0, 0);
          filterGraph.Object.ConnectDirect(smartTee, aviDec2, 1, 0).Next(colour2, 0, 0).Next(render, 0, 0);

          IVideoWindow vw = (IVideoWindow)filterGraph.Object;
          vw.put_Owner(Handle);
          vw.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings | WindowStyle.ClipChildren);
          vw.SetWindowPosition(0, 0, Width, Height);

          pBuilder.Object.RenderStream(PinCategory.Capture, MediaType.Video, videoSource, null, null);
        }
        finally
        {
          foreach (var obj in disposableObjects)
          {
            obj.Dispose();
          }
        } 
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

    private DShowObject<IFilterGraph2> filterGraph;
    private IMediaControl mediaControl;

    private readonly Dictionary<string, DsDevice> _dsDevices;
  }
}