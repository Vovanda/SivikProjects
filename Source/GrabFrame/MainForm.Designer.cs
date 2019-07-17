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
      this.canvas = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.saveBtn = new System.Windows.Forms.Button();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.camComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.sizeInfoLabel = new System.Windows.Forms.ToolStrip();
      this.sizeInfoLable = new System.Windows.Forms.ToolStripLabel();
      this.frameLabel = new System.Windows.Forms.ToolStripLabel();
      this.toolStrip.SuspendLayout();
      this.sizeInfoLabel.SuspendLayout();
      this.SuspendLayout();
      // 
      // canvas
      // 
      this.canvas.BackColor = System.Drawing.Color.Black;
      this.canvas.Location = new System.Drawing.Point(12, 28);
      this.canvas.Name = "canvas";
      this.canvas.Size = new System.Drawing.Size(224, 114);
      this.canvas.TabIndex = 0;
      this.canvas.SizeChanged += new System.EventHandler(this.OnCanvasSizeChanged);
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
      this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.panel2.Location = new System.Drawing.Point(12, 298);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(130, 94);
      this.panel2.TabIndex = 3;
      // 
      // saveBtn
      // 
      this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.saveBtn.Location = new System.Drawing.Point(658, 349);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(99, 43);
      this.saveBtn.TabIndex = 2;
      this.saveBtn.Text = "Сохранить";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
      // 
      // timer
      // 
      this.timer.Tick += new System.EventHandler(this.OnTimerTick);
      // 
      // toolStrip
      // 
      this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1,
            this.camComboBox});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolStrip.Size = new System.Drawing.Size(769, 25);
      this.toolStrip.TabIndex = 4;
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripButton1.Image = global::GrabFrame.Properties.Resources.settings;
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size(87, 22);
      this.toolStripButton1.Text = "Настройки";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
      this.toolStripLabel1.Image = global::GrabFrame.Properties.Resources.webcam;
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
      this.toolStripLabel1.Text = "Источник:";
      // 
      // camComboBox
      // 
      this.camComboBox.Name = "camComboBox";
      this.camComboBox.Size = new System.Drawing.Size(121, 25);
      this.camComboBox.SelectedIndexChanged += new System.EventHandler(this.OnCamComboBoxSelectedIndexChanged);
      // 
      // sizeInfoLabel
      // 
      this.sizeInfoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.sizeInfoLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.sizeInfoLabel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.sizeInfoLabel.ImageScalingSize = new System.Drawing.Size(16, 18);
      this.sizeInfoLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeInfoLable,
            this.frameLabel});
      this.sizeInfoLabel.Location = new System.Drawing.Point(0, 402);
      this.sizeInfoLabel.Name = "sizeInfoLabel";
      this.sizeInfoLabel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.sizeInfoLabel.Size = new System.Drawing.Size(769, 25);
      this.sizeInfoLabel.TabIndex = 5;
      // 
      // sizeInfoLable
      // 
      this.sizeInfoLable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sizeInfoLable.BackColor = System.Drawing.Color.Transparent;
      this.sizeInfoLable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.sizeInfoLable.Image = global::GrabFrame.Properties.Resources.size;
      this.sizeInfoLable.Name = "sizeInfoLable";
      this.sizeInfoLable.Size = new System.Drawing.Size(83, 22);
      this.sizeInfoLable.Text = " 640 x 480";
      this.sizeInfoLable.Click += new System.EventHandler(this.sizeInfoLable_Click);
      // 
      // frameLabel
      // 
      this.frameLabel.BackColor = System.Drawing.Color.Transparent;
      this.frameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.frameLabel.Name = "frameLabel";
      this.frameLabel.Size = new System.Drawing.Size(31, 22);
      this.frameLabel.Text = "FPS:";
      // 
      // MainForm
      // 
      this.BackColor = System.Drawing.Color.PaleTurquoise;
      this.ClientSize = new System.Drawing.Size(769, 427);
      this.Controls.Add(this.sizeInfoLabel);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.canvas);
      this.Name = "MainForm";
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.sizeInfoLabel.ResumeLayout(false);
      this.sizeInfoLabel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel canvas;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button saveBtn;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripComboBox camComboBox;
    private System.Windows.Forms.ToolStrip sizeInfoLabel;
    private System.Windows.Forms.ToolStripLabel sizeInfoLable;
    private System.Windows.Forms.ToolStripLabel frameLabel;
  }
}

