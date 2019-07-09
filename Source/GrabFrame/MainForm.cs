
using System.Windows.Forms;
using DirectShowHelper;
using DirectShowLib;

namespace GrabFrame
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      DsDevice[] divices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
      BuildGraph(divices[1]);
    }
    IVideoWindow vw;

    private void BuildGraph(DsDevice device)
    {
      var graph = (IFilterGraph2)new FilterGraph();
      var mediaControl = (IMediaControl)graph;
      var pBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
      pBuilder.SetFiltergraph(graph);
      IBaseFilter videoSourceBaseFilter = DSHelper.GetVideoSourceBaseFilter(device);   
      var smartTee = (IBaseFilter)new SmartTee();
      graph.AddFilters(videoSourceBaseFilter, smartTee);


      var aviDec1 = (IBaseFilter)new AVIDec();
      var colour1 = (IBaseFilter)new Colour();
      var grabber = (IBaseFilter)new SampleGrabber();
      graph.AddFilters(aviDec1, colour1, grabber);

      var aviDec2 = (IBaseFilter)new AVIDec();
      var colour2 = (IBaseFilter)new Colour();
      var render = (IBaseFilter)new VideoRenderer();
      graph.AddFilters(aviDec2, colour2, render);

      graph.ConnectDirect(videoSourceBaseFilter, smartTee, 0, 0);
      graph.ConnectDirect(smartTee, aviDec1, 0, 0).NextConnectDirect(colour1, 0, 0).NextConnectDirect(grabber, 0, 0);
      graph.ConnectDirect(smartTee, aviDec2, 1, 0).NextConnectDirect(colour2, 0, 0).NextConnectDirect(render, 0, 0);
      
      vw = (IVideoWindow)graph;
      vw.put_Owner(canvas.Handle);
      vw.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings | WindowStyle.ClipChildren);
      vw.SetWindowPosition(0, 0, canvas.Width, canvas.Height);

      pBuilder.RenderStream(PinCategory.Capture, MediaType.Video, videoSourceBaseFilter, null, null);

      mediaControl.Run();
    }

    private void canvas_SizeChanged(object sender, System.EventArgs e)
    {
      if (vw != null)
      {
        vw.SetWindowPosition(0, 0, canvas.Width, canvas.Height);
      }
    }
  }


}
