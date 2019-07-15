using System.Drawing;
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
      timer1.Start();
    }

    private void OnCanvasSizeChanged(object sender, System.EventArgs e)
    {
      _webCamCapture.SetCanvasSize(canvas.Size);
    }

    private void OnCamComboBoxSelectedIndexChanged(object sender, System.EventArgs e)
    {
      _webCamCapture.SetCurentDevice((sender as ToolStripComboBox).SelectedItem.ToString());
    }
        
    private void OnSaveBtnClick(object sender, System.EventArgs e)
    {
      if (saveBtnActive)
      {
        saveBtnActive = false;
        if (_webCamCapture.GetBitmap() is Bitmap image && image != null)
        {
          panel2.BackgroundImage = image;
        }
        saveBtnActive = true;
      }
    }
    private bool saveBtnActive = true;
    private readonly WebCamCapture _webCamCapture;

    private void timer1_Tick(object sender, System.EventArgs e)
    {
      label1.Text = _webCamCapture.FrameRate.ToString();
    }
  }
}
