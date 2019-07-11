using System.Windows.Forms;

namespace GrabFrame
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      _webCamCapture = new WebCamCapture(canvas.Handle, canvas.Width, canvas.Height);
      camComboBox.Items.AddRange(_webCamCapture.GetDevicesNames());
      camComboBox.SelectedItem = WebCamCapture.NameOfNoneDevice; 
    }

    private void canvas_SizeChanged(object sender, System.EventArgs e)
    {
      _webCamCapture.SetCanvasSize(canvas.Size);
    }


    private void OnCamComboBoxSelectedIndexChanged(object sender, System.EventArgs e)
    {
      _webCamCapture.SetCurentDevice((sender as ToolStripComboBox).SelectedItem.ToString());
    }

    private readonly WebCamCapture _webCamCapture;
  }
}
