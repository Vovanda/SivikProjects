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
      this.panel1 = new System.Windows.Forms.Panel();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.camComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.saveBtn = new System.Windows.Forms.Button();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // canvas
      // 
      this.canvas.BackColor = System.Drawing.Color.Transparent;
      this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.canvas.Location = new System.Drawing.Point(0, 29);
      this.canvas.Name = "canvas";
      this.canvas.Size = new System.Drawing.Size(769, 398);
      this.canvas.TabIndex = 0;
      this.canvas.SizeChanged += new System.EventHandler(this.OnCanvasSizeChanged);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.toolStrip1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(769, 29);
      this.panel1.TabIndex = 1;
      // 
      // toolStrip1
      // 
      this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camComboBox});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(769, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // camComboBox
      // 
      this.camComboBox.Name = "camComboBox";
      this.camComboBox.Size = new System.Drawing.Size(121, 25);
      this.camComboBox.SelectedIndexChanged += new System.EventHandler(this.OnCamComboBoxSelectedIndexChanged);
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
      this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.panel2.Location = new System.Drawing.Point(13, 321);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(130, 94);
      this.panel2.TabIndex = 3;
      // 
      // saveBtn
      // 
      this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.saveBtn.Location = new System.Drawing.Point(621, 367);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(136, 48);
      this.saveBtn.TabIndex = 2;
      this.saveBtn.Text = "Сохранить";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(181, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      // 
      // MainForm
      // 
      this.BackColor = System.Drawing.Color.PaleTurquoise;
      this.ClientSize = new System.Drawing.Size(769, 427);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.canvas);
      this.Controls.Add(this.panel1);
      this.Name = "MainForm";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel canvas;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripComboBox camComboBox;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button saveBtn;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label1;
  }
}

