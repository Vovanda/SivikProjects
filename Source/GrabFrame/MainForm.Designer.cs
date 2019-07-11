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
      this.canvas = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.camComboBox = new System.Windows.Forms.ToolStripComboBox();
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
      this.canvas.SizeChanged += new System.EventHandler(this.canvas_SizeChanged);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
      this.camComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.camComboBox.Name = "camComboBox";
      this.camComboBox.Size = new System.Drawing.Size(121, 25);
      this.camComboBox.SelectedIndexChanged += new System.EventHandler(this.OnCamComboBoxSelectedIndexChanged);
      // 
      // MainForm
      // 
      this.BackColor = System.Drawing.Color.PaleTurquoise;
      this.ClientSize = new System.Drawing.Size(769, 427);
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
  }
}

