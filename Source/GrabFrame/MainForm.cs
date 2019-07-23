using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GrabFrame.Common.Imaging;

namespace GrabFrame
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      _deviceManager = new DeviceManager();
      _webCamCapture = new WebCamCapture(canvas.Handle, canvas.Width, canvas.Height);
      canvas.Dock = DockStyle.Fill;
      settingsForm = new SettingsDialogForm();
      timer.Start();
    }

    private void OnFormLoad(object sender, System.EventArgs e)
    {
      toolStripLabelInfo.Text = string.Empty;
      if (Properties.Settings.Default.SaveSelectedCam)
      {
        CaptureStart(Properties.Settings.Default.DeviceName);
      }
      camComboBox.Items.Clear();
      camComboBox.Items.AddRange(_deviceManager.DevicesNames.ToArray());
      camComboBox.SelectedItem = _deviceManager.SelectedDiviceName;
    }

    private void OnCamComboBoxSelectedIndexChanged(object sender, System.EventArgs e)
    {
      string deviceName = (string)(sender as ToolStripComboBox).SelectedItem;
      mainPanel.Focus();
      CaptureStart(deviceName);
    }

    private void CaptureStart(string deviceName)
    {
      if (_deviceManager.SelectedDiviceName != deviceName)
      {
        var device = _deviceManager.GetDeviceByName(deviceName);
        bool deviceIsExist = device != null;
        if (deviceIsExist)
        {
          _webCamCapture.SetCurentDevice(device);
          sizeInfoLabel.Text = $"{_webCamCapture.VideoWidth} x {_webCamCapture.VideoHeight}";
          toolStripSaveBtn.Visible = Properties.Settings.Default.ToolStripSaveBtn;
          saveBtn.Visible = !toolStripSaveBtn.Visible;
        }
        else
        {
          saveBtn.Visible = false;
          toolStripSaveBtn.Visible = false;
          _webCamCapture.Stop();
        }
        canvas.Refresh();
        canvas.Visible = deviceIsExist;
        sizeInfoLabel.Visible = deviceIsExist;
      }
    }

    private void OnCamComboBoxDropDown(object sender, System.EventArgs e)
    {
      camComboBox.Items.Clear();
      camComboBox.Items.AddRange(_deviceManager.DevicesNames.ToArray());
      camComboBox.SelectedItem = _deviceManager.SelectedDiviceName;
    }

    private void OnSaveBtnClick(object sender, System.EventArgs e) => SaveScan();

    private void SaveScan()
    {
      SetInfoAboutPathToSaveImage();
      if (!PathToSaveImageNotExist && _webCamCapture.GetBitmap() is Bitmap image && image != null)
      {
        string targetFormat = Properties.Settings.Default.ImageFormat;
        string targetPath = GetTargetPathToFolder();
        string scanName = _deviceManager.SelectedDiviceName + "_scan_";        
        int scanIndex = GetNextIndexOfScan(targetPath, scanName);

        if (!Directory.Exists(targetPath))
        {
          Directory.CreateDirectory(targetPath);
        }

        image.Save(Path.Combine(targetPath, $"{scanName}{scanIndex}.{targetFormat}"), Imaging.GetAllowedImageFormatByName(targetFormat));
      }

      #region Helper methods

      string GetTargetPathToFolder()
      {
        bool createFolderForCam = Properties.Settings.Default.CreateFolderForCam;
        string rootPath = Properties.Settings.Default.PathToSaveImage;        
        return createFolderForCam ? Path.Combine(rootPath, _deviceManager.SelectedDiviceName) : rootPath;
      }

      int GetNextIndexOfScan(string targetPath, string scanName)
      {
        if (Directory.Exists(targetPath))
        {
          var rgx = new Regex($@"{scanName}(\d+)\.({string.Join("|", Imaging.AllowedImageFormatsNames)})$", RegexOptions.IgnoreCase);
          int lastScanIdx = Directory.GetFiles(targetPath, scanName + "*").Select(x => Path.GetFileName(x))
            .Select(x => rgx.Match(x)).Where(m => m.Success).Select(m => int.Parse(m.Groups[1].Value)).DefaultIfEmpty().Max();
          return lastScanIdx + 1;
        }
        return 1;
      }
      #endregion
    }

    private void OnCanvasResize(object sender, System.EventArgs e)
    {
      _webCamCapture.SetCanvasSize(canvas.Size);
    }

    private void OnTimerTick(object sender, System.EventArgs e)
    {
      frameLabel.Text = $"FPS: {_webCamCapture.FrameRate}";
    }

    private void OnSettingsButtonClick(object sender, System.EventArgs e)
    {
      settingsForm.StartPosition = FormStartPosition.CenterParent;
      settingsForm.ShowDialog();
      toolStripSaveBtn.Visible = Properties.Settings.Default.ToolStripSaveBtn;
      saveBtn.Visible = !toolStripSaveBtn.Visible;
      SetInfoAboutPathToSaveImage();
    }

    private bool PathToSaveImageNotExist => string.IsNullOrEmpty(Properties.Settings.Default.PathToSaveImage);

    private void SetInfoAboutPathToSaveImage()
    {
      toolStripLabelInfo.Text = "";
      if (PathToSaveImageNotExist)
      {
        toolStripLabelInfo.Text = "Укажите путь сохранения снимков!";
      }
      toolStripLabelInfo.Visible = PathToSaveImageNotExist;
    }
    
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      if (Properties.Settings.Default.SaveSelectedCam)
      {
        Properties.Settings.Default.DeviceName = _deviceManager.SelectedDiviceName;
      }
      else
      {
        Properties.Settings.Default.DeviceName = "";
      }
      Properties.Settings.Default.Save();
    }
    
    private bool CreateFolderForCam => Properties.Settings.Default.CreateFolderForCam;

    private readonly WebCamCapture _webCamCapture;
    private readonly DeviceManager _deviceManager;
    private readonly SettingsDialogForm settingsForm;
  }
}
