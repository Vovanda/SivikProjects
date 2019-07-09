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
      this.SuspendLayout();
      // 
      // canvas
      // 
      this.canvas.BackColor = System.Drawing.Color.Transparent;
      this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.canvas.Location = new System.Drawing.Point(0, 0);
      this.canvas.Name = "canvas";
      this.canvas.Size = new System.Drawing.Size(769, 427);
      this.canvas.TabIndex = 0;
      this.canvas.SizeChanged += new System.EventHandler(this.canvas_SizeChanged);
      // 
      // MainForm
      // 
      this.ClientSize = new System.Drawing.Size(769, 427);
      this.Controls.Add(this.canvas);
      this.Name = "MainForm";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel canvas;
  }
}

