namespace WindowsFormsApp2
{
  partial class Downloader
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
      this.labelSpeed = new System.Windows.Forms.Label();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.labelDownloaded = new System.Windows.Forms.Label();
      this.labelPerc = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // labelSpeed
      // 
      this.labelSpeed.AutoSize = true;
      this.labelSpeed.Location = new System.Drawing.Point(383, 122);
      this.labelSpeed.Name = "labelSpeed";
      this.labelSpeed.Size = new System.Drawing.Size(46, 17);
      this.labelSpeed.TabIndex = 0;
      this.labelSpeed.Text = "label1";
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(199, 202);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(294, 64);
      this.progressBar.TabIndex = 1;
      // 
      // labelDownloaded
      // 
      this.labelDownloaded.AutoSize = true;
      this.labelDownloaded.Location = new System.Drawing.Point(444, 49);
      this.labelDownloaded.Name = "labelDownloaded";
      this.labelDownloaded.Size = new System.Drawing.Size(46, 17);
      this.labelDownloaded.TabIndex = 2;
      this.labelDownloaded.Text = "label1";
      // 
      // labelPerc
      // 
      this.labelPerc.AutoSize = true;
      this.labelPerc.Location = new System.Drawing.Point(585, 83);
      this.labelPerc.Name = "labelPerc";
      this.labelPerc.Size = new System.Drawing.Size(46, 17);
      this.labelPerc.TabIndex = 3;
      this.labelPerc.Text = "label1";
      this.labelPerc.Click += new System.EventHandler(this.label1_Click);
      // 
      // Downloader
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.labelPerc);
      this.Controls.Add(this.labelDownloaded);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.labelSpeed);
      this.Name = "Downloader";
      this.Text = "Downloader";
      this.Load += new System.EventHandler(this.Downloader_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelSpeed;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label labelDownloaded;
    private System.Windows.Forms.Label labelPerc;
  }
}