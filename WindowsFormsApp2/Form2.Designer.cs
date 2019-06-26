namespace WindowsFormsApp2
{
  partial class frmWaitDialog
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
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.lblTempoRimanente = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(49, 56);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(655, 44);
      this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.progressBar1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(46, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(395, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Sto Caricando la Lista dei file da Scaricare....Attendere Prego";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(568, 106);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(136, 35);
      this.button1.TabIndex = 2;
      this.button1.Text = "Annulla";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // lblTempoRimanente
      // 
      this.lblTempoRimanente.AutoSize = true;
      this.lblTempoRimanente.Location = new System.Drawing.Point(375, 113);
      this.lblTempoRimanente.Name = "lblTempoRimanente";
      this.lblTempoRimanente.Size = new System.Drawing.Size(46, 17);
      this.lblTempoRimanente.TabIndex = 3;
      this.lblTempoRimanente.Text = "label2";
      // 
      // frmWaitDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(768, 150);
      this.ControlBox = false;
      this.Controls.Add(this.lblTempoRimanente);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.progressBar1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "frmWaitDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Form2";
      this.Load += new System.EventHandler(this.Form2_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    public System.Windows.Forms.Label lblTempoRimanente;
  }
}