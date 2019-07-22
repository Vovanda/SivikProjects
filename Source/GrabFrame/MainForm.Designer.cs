namespace GrabFrame
{
  partial class MainForm
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.settingButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabelCam = new System.Windows.Forms.ToolStripLabel();
      this.camComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.sizeInfoToolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripSaveBtn = new System.Windows.Forms.ToolStripButton();
      this.sizeInfoLabel = new System.Windows.Forms.ToolStripLabel();
      this.toolStripLabelInfo = new System.Windows.Forms.ToolStripLabel();
      this.frameLabel = new System.Windows.Forms.ToolStripLabel();
      this.canvas = new System.Windows.Forms.PictureBox();
      this.saveBtn = new System.Windows.Forms.Button();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.toolStrip.SuspendLayout();
      this.sizeInfoToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
      this.mainPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // timer
      // 
      this.timer.Tick += new System.EventHandler(this.OnTimerTick);
      // 
      // toolStrip
      // 
      this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingButton,
            this.toolStripLabelCam,
            this.camComboBox});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolStrip.Size = new System.Drawing.Size(640, 25);
      this.toolStrip.TabIndex = 4;
      // 
      // settingButton
      // 
      this.settingButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.settingButton.Image = global::GrabFrame.Properties.Resources.settings;
      this.settingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.settingButton.Name = "settingButton";
      this.settingButton.Size = new System.Drawing.Size(87, 22);
      this.settingButton.Text = "Настройки";
      this.settingButton.Click += new System.EventHandler(this.OnSettingsButtonClick);
      // 
      // toolStripLabelCam
      // 
      this.toolStripLabelCam.BackColor = System.Drawing.Color.Transparent;
      this.toolStripLabelCam.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabelCam.Image")));
      this.toolStripLabelCam.Name = "toolStripLabelCam";
      this.toolStripLabelCam.Size = new System.Drawing.Size(67, 22);
      this.toolStripLabelCam.Text = "Камера:";
      // 
      // camComboBox
      // 
      this.camComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.camComboBox.Name = "camComboBox";
      this.camComboBox.Size = new System.Drawing.Size(121, 25);
      this.camComboBox.DropDown += new System.EventHandler(this.OnCamComboBoxDropDown);
      this.camComboBox.SelectedIndexChanged += new System.EventHandler(this.OnCamComboBoxSelectedIndexChanged);
      // 
      // sizeInfoToolStrip
      // 
      this.sizeInfoToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.sizeInfoToolStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.sizeInfoToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.sizeInfoToolStrip.ImageScalingSize = new System.Drawing.Size(16, 18);
      this.sizeInfoToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSaveBtn,
            this.sizeInfoLabel,
            this.toolStripLabelInfo,
            this.frameLabel});
      this.sizeInfoToolStrip.Location = new System.Drawing.Point(0, 505);
      this.sizeInfoToolStrip.Name = "sizeInfoToolStrip";
      this.sizeInfoToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.sizeInfoToolStrip.Size = new System.Drawing.Size(640, 25);
      this.sizeInfoToolStrip.TabIndex = 5;
      // 
      // toolStripSaveBtn
      // 
      this.toolStripSaveBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripSaveBtn.BackColor = System.Drawing.Color.Black;
      this.toolStripSaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSaveBtn.Image")));
      this.toolStripSaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripSaveBtn.Margin = new System.Windows.Forms.Padding(100, 1, 10, 1);
      this.toolStripSaveBtn.Name = "toolStripSaveBtn";
      this.toolStripSaveBtn.Size = new System.Drawing.Size(70, 23);
      this.toolStripSaveBtn.Text = "Сохранить";
      this.toolStripSaveBtn.Visible = false;
      this.toolStripSaveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
      // 
      // sizeInfoLabel
      // 
      this.sizeInfoLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sizeInfoLabel.BackColor = System.Drawing.Color.Transparent;
      this.sizeInfoLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.sizeInfoLabel.Image = global::GrabFrame.Properties.Resources.size;
      this.sizeInfoLabel.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
      this.sizeInfoLabel.Name = "sizeInfoLabel";
      this.sizeInfoLabel.Size = new System.Drawing.Size(16, 23);
      this.sizeInfoLabel.Visible = false;
      // 
      // toolStripLabelInfo
      // 
      this.toolStripLabelInfo.BackColor = System.Drawing.Color.Transparent;
      this.toolStripLabelInfo.ForeColor = System.Drawing.Color.OrangeRed;
      this.toolStripLabelInfo.Name = "toolStripLabelInfo";
      this.toolStripLabelInfo.Size = new System.Drawing.Size(62, 22);
      this.toolStripLabelInfo.Text = "Some info";
      // 
      // frameLabel
      // 
      this.frameLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.frameLabel.BackColor = System.Drawing.Color.Transparent;
      this.frameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.frameLabel.Margin = new System.Windows.Forms.Padding(5, 1, 100, 1);
      this.frameLabel.Name = "frameLabel";
      this.frameLabel.Size = new System.Drawing.Size(31, 23);
      this.frameLabel.Text = "FPS:";
      // 
      // canvas
      // 
      this.canvas.BackColor = System.Drawing.Color.Black;
      this.canvas.ErrorImage = null;
      this.canvas.InitialImage = null;
      this.canvas.Location = new System.Drawing.Point(3, 3);
      this.canvas.Name = "canvas";
      this.canvas.Size = new System.Drawing.Size(184, 140);
      this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.canvas.TabIndex = 6;
      this.canvas.TabStop = false;
      this.canvas.Visible = false;
      this.canvas.Resize += new System.EventHandler(this.OnCanvasResize);
      // 
      // saveBtn
      // 
      this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.saveBtn.Location = new System.Drawing.Point(546, 457);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(82, 38);
      this.saveBtn.TabIndex = 7;
      this.saveBtn.Text = "Сохранить";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Visible = false;
      this.saveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
      // 
      // mainPanel
      // 
      this.mainPanel.BackgroundImage = global::GrabFrame.Properties.Resources.WebcamIsNotSelected;
      this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.mainPanel.Controls.Add(this.canvas);
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(0, 25);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(640, 480);
      this.mainPanel.TabIndex = 8;
      // 
      // MainForm
      // 
      this.BackColor = System.Drawing.Color.Black;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.ClientSize = new System.Drawing.Size(640, 530);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.sizeInfoToolStrip);
      this.Controls.Add(this.toolStrip);
      this.DoubleBuffered = true;
      this.Name = "MainForm";
      this.Text = "Grab Frame";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
      this.Load += new System.EventHandler(this.OnFormLoad);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.sizeInfoToolStrip.ResumeLayout(false);
      this.sizeInfoToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
      this.mainPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton settingButton;
    private System.Windows.Forms.ToolStripLabel toolStripLabelCam;
    private System.Windows.Forms.ToolStripComboBox camComboBox;
    private System.Windows.Forms.ToolStrip sizeInfoToolStrip;
    private System.Windows.Forms.ToolStripLabel sizeInfoLabel;
    private System.Windows.Forms.ToolStripLabel frameLabel;
    private System.Windows.Forms.PictureBox canvas;
    private System.Windows.Forms.ToolStripButton toolStripSaveBtn;
    private System.Windows.Forms.ToolStripLabel toolStripLabelInfo;
    private System.Windows.Forms.Button saveBtn;
    private System.Windows.Forms.Panel mainPanel;
  }
}

