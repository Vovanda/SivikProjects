namespace GrabFrame
{
  partial class SettingsDialogForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.openFolderDialogButton = new System.Windows.Forms.Button();
      this.labelImageDir = new System.Windows.Forms.Label();
      this.textBoxSelectedPath = new System.Windows.Forms.TextBox();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.radioButtonCreateCamFolder = new System.Windows.Forms.RadioButton();
      this.radioButtonAddCamName = new System.Windows.Forms.RadioButton();
      this.checkBoxSaveSelectedCam = new System.Windows.Forms.CheckBox();
      this.checkBoxToolStripSaveBtn = new System.Windows.Forms.CheckBox();
      this.labelImageFormat = new System.Windows.Forms.Label();
      this.comboBoxImageFormats = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // openFolderDialogButton
      // 
      this.openFolderDialogButton.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.openFolderDialogButton.Location = new System.Drawing.Point(309, 33);
      this.openFolderDialogButton.Name = "openFolderDialogButton";
      this.openFolderDialogButton.Size = new System.Drawing.Size(84, 25);
      this.openFolderDialogButton.TabIndex = 2;
      this.openFolderDialogButton.Text = "🖿 Обзор...";
      this.openFolderDialogButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.openFolderDialogButton.UseVisualStyleBackColor = true;
      this.openFolderDialogButton.Click += new System.EventHandler(this.OnOpenFolderDialogButtonClick);
      // 
      // labelImageDir
      // 
      this.labelImageDir.AutoSize = true;
      this.labelImageDir.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.labelImageDir.Location = new System.Drawing.Point(18, 9);
      this.labelImageDir.Name = "labelImageDir";
      this.labelImageDir.Size = new System.Drawing.Size(131, 16);
      this.labelImageDir.TabIndex = 3;
      this.labelImageDir.Text = "Сохранять снимки в:";
      // 
      // textBoxSelectedPath
      // 
      this.textBoxSelectedPath.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.textBoxSelectedPath.Location = new System.Drawing.Point(18, 34);
      this.textBoxSelectedPath.Name = "textBoxSelectedPath";
      this.textBoxSelectedPath.Size = new System.Drawing.Size(288, 23);
      this.textBoxSelectedPath.TabIndex = 4;
      this.textBoxSelectedPath.TextChanged += new System.EventHandler(this.OnTextBoxSelectedPathTextChanged);
      // 
      // errorProvider
      // 
      this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      this.errorProvider.ContainerControl = this;
      // 
      // radioButtonCreateCamFolder
      // 
      this.radioButtonCreateCamFolder.AutoSize = true;
      this.radioButtonCreateCamFolder.Checked = true;
      this.radioButtonCreateCamFolder.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.radioButtonCreateCamFolder.Location = new System.Drawing.Point(18, 97);
      this.radioButtonCreateCamFolder.Name = "radioButtonCreateCamFolder";
      this.radioButtonCreateCamFolder.Size = new System.Drawing.Size(288, 20);
      this.radioButtonCreateCamFolder.TabIndex = 5;
      this.radioButtonCreateCamFolder.TabStop = true;
      this.radioButtonCreateCamFolder.Text = "Создавать каталог с названием веб-камеры";
      this.radioButtonCreateCamFolder.UseVisualStyleBackColor = true;
      this.radioButtonCreateCamFolder.CheckedChanged += new System.EventHandler(this.OnRadioButtonCreateCamFolderCheckedChanged);
      // 
      // radioButtonAddCamName
      // 
      this.radioButtonAddCamName.AutoSize = true;
      this.radioButtonAddCamName.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.radioButtonAddCamName.Location = new System.Drawing.Point(18, 121);
      this.radioButtonAddCamName.Name = "radioButtonAddCamName";
      this.radioButtonAddCamName.Size = new System.Drawing.Size(312, 20);
      this.radioButtonAddCamName.TabIndex = 6;
      this.radioButtonAddCamName.Text = "Добавлять название камеры в название снимка";
      this.radioButtonAddCamName.UseVisualStyleBackColor = true;
      // 
      // checkBoxSaveSelectedCam
      // 
      this.checkBoxSaveSelectedCam.AutoSize = true;
      this.checkBoxSaveSelectedCam.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.checkBoxSaveSelectedCam.Location = new System.Drawing.Point(18, 156);
      this.checkBoxSaveSelectedCam.Name = "checkBoxSaveSelectedCam";
      this.checkBoxSaveSelectedCam.Size = new System.Drawing.Size(277, 20);
      this.checkBoxSaveSelectedCam.TabIndex = 7;
      this.checkBoxSaveSelectedCam.Text = "Сохранять последнюю выбранную камеру";
      this.checkBoxSaveSelectedCam.UseVisualStyleBackColor = true;
      this.checkBoxSaveSelectedCam.CheckedChanged += new System.EventHandler(this.OnCheckBoxSaveSelectedCamCheckedChanged);
      // 
      // checkBoxToolStripSaveBtn
      // 
      this.checkBoxToolStripSaveBtn.AutoSize = true;
      this.checkBoxToolStripSaveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F);
      this.checkBoxToolStripSaveBtn.Location = new System.Drawing.Point(18, 178);
      this.checkBoxToolStripSaveBtn.Name = "checkBoxToolStripSaveBtn";
      this.checkBoxToolStripSaveBtn.Size = new System.Drawing.Size(304, 20);
      this.checkBoxToolStripSaveBtn.TabIndex = 7;
      this.checkBoxToolStripSaveBtn.Text = "Убрать кнопку \"Сохранить\" в строку состояния";
      this.checkBoxToolStripSaveBtn.UseVisualStyleBackColor = true;
      this.checkBoxToolStripSaveBtn.CheckedChanged += new System.EventHandler(this.OnCheckBoxToolStripSaveBtnCheckedChanged);
      // 
      // labelImageFormat
      // 
      this.labelImageFormat.AutoSize = true;
      this.labelImageFormat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labelImageFormat.Location = new System.Drawing.Point(18, 71);
      this.labelImageFormat.Name = "labelImageFormat";
      this.labelImageFormat.Size = new System.Drawing.Size(288, 14);
      this.labelImageFormat.TabIndex = 8;
      this.labelImageFormat.Text = "Используемый формат для сохранения снимков:";
      // 
      // comboBoxImageFormats
      // 
      this.comboBoxImageFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxImageFormats.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.comboBoxImageFormats.FormattingEnabled = true;
      this.comboBoxImageFormats.Location = new System.Drawing.Point(309, 67);
      this.comboBoxImageFormats.Name = "comboBoxImageFormats";
      this.comboBoxImageFormats.Size = new System.Drawing.Size(84, 22);
      this.comboBoxImageFormats.TabIndex = 9;
      this.comboBoxImageFormats.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxSelectedIndexChanged);
      // 
      // SettingsDialogForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(410, 206);
      this.Controls.Add(this.comboBoxImageFormats);
      this.Controls.Add(this.labelImageFormat);
      this.Controls.Add(this.checkBoxToolStripSaveBtn);
      this.Controls.Add(this.checkBoxSaveSelectedCam);
      this.Controls.Add(this.radioButtonAddCamName);
      this.Controls.Add(this.radioButtonCreateCamFolder);
      this.Controls.Add(this.openFolderDialogButton);
      this.Controls.Add(this.textBoxSelectedPath);
      this.Controls.Add(this.labelImageDir);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(426, 245);
      this.MinimizeBox = false;
      this.Name = "SettingsDialogForm";
      this.Text = "Настройки";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
      this.Load += new System.EventHandler(this.OnFormLoad);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private System.Windows.Forms.Button openFolderDialogButton;
    private System.Windows.Forms.Label labelImageDir;
    private System.Windows.Forms.TextBox textBoxSelectedPath;
    private System.Windows.Forms.ErrorProvider errorProvider;
    private System.Windows.Forms.RadioButton radioButtonAddCamName;
    private System.Windows.Forms.RadioButton radioButtonCreateCamFolder;
    private System.Windows.Forms.CheckBox checkBoxSaveSelectedCam;
    private System.Windows.Forms.CheckBox checkBoxToolStripSaveBtn;
    private System.Windows.Forms.Label labelImageFormat;
    private System.Windows.Forms.ComboBox comboBoxImageFormats;
  }
}