using GrabFrame.Common.Imaging;
using System;
using System.IO;
using System.Windows.Forms;

namespace GrabFrame
{
  public partial class SettingsDialogForm : Form
  {
    public SettingsDialogForm()
    {
      InitializeComponent();
            
      comboBoxImageFormats.Items.AddRange(Imaging.AllowedImageFormatsNames);
      comboBoxImageFormats.Text = Properties.Settings.Default.ImageFormat;
      errorProvider.SetIconAlignment(textBoxSelectedPath, ErrorIconAlignment.MiddleLeft);

      checkBoxSaveSelectedCam.Checked = Properties.Settings.Default.SaveSelectedCam;
      checkBoxToolStripSaveBtn.Checked = Properties.Settings.Default.ToolStripSaveBtn;
    
      radioButtonCreateCamFolder.Checked = Properties.Settings.Default.CreateFolderForCam;
      radioButtonAddCamName.Checked = !radioButtonCreateCamFolder.Checked;
    }
    
    public bool PathToSaveImageIsCorrect { get; private set; }

    public string PathToSaveImage => Properties.Settings.Default.PathToSaveImage;

    private void OnFormLoad(object sender, EventArgs e)
    {
      textBoxSelectedPath.Text = Properties.Settings.Default.PathToSaveImage;
    }
    private void OnFormClosed(object sender, FormClosedEventArgs e)
    {
      if (PathToSaveImageIsCorrect)
      {
        Properties.Settings.Default.PathToSaveImage = textBoxSelectedPath.Text;
        DialogResult = DialogResult.OK;
      }
      else
      {
        DialogResult = DialogResult.Abort;
      }
      Properties.Settings.Default.Save();
    }

    private void OnOpenFolderDialogButtonClick(object sender, EventArgs e)
    {
      if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        textBoxSelectedPath.Text = folderBrowserDialog.SelectedPath;
      }
    }

    private void OnTextBoxSelectedPathTextChanged(object sender, EventArgs e)
    {
      PathToSaveImageIsCorrect = Directory.Exists(textBoxSelectedPath.Text);
      if (PathToSaveImageIsCorrect)
      {
        errorProvider.SetError(textBoxSelectedPath, string.Empty);
      }
      else
      {
        errorProvider.SetError(textBoxSelectedPath, "Путь не является корректным!");
      }
    }
    
    private void OnRadioButtonCreateCamFolderCheckedChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.CreateFolderForCam = radioButtonCreateCamFolder.Checked;
    }

    private void OnCheckBoxSaveSelectedCamCheckedChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.SaveSelectedCam = checkBoxSaveSelectedCam.Checked;
    }

    private void OnCheckBoxToolStripSaveBtnCheckedChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.ToolStripSaveBtn = checkBoxToolStripSaveBtn.Checked;
    }

    private void OnComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.ImageFormat = comboBoxImageFormats.SelectedItem.ToString();
    }
  }
}
