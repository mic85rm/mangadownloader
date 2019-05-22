namespace MangaEdenNETDownloader
{
  partial class Form1
  {
    /// <summary>
    /// Variabile di progettazione necessaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Pulire le risorse in uso.
    /// </summary>
    /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Codice generato da Progettazione Windows Form

    /// <summary>
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      this.lblNumeroCapitoli = new System.Windows.Forms.Label();
      this.txtLinkManga = new System.Windows.Forms.TextBox();
      this.lstbxListaCapitoli = new System.Windows.Forms.ListBox();
      this.lstbxListaLinkDownload = new System.Windows.Forms.ListBox();
      this.btnScarica = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblNumeroCapitoli
      // 
      this.lblNumeroCapitoli.AutoSize = true;
      this.lblNumeroCapitoli.Location = new System.Drawing.Point(751, 19);
      this.lblNumeroCapitoli.Name = "lblNumeroCapitoli";
      this.lblNumeroCapitoli.Size = new System.Drawing.Size(112, 17);
      this.lblNumeroCapitoli.TabIndex = 0;
      this.lblNumeroCapitoli.Text = "Numero Capitoli:";
      // 
      // txtLinkManga
      // 
      this.txtLinkManga.Location = new System.Drawing.Point(33, 49);
      this.txtLinkManga.Name = "txtLinkManga";
      this.txtLinkManga.Size = new System.Drawing.Size(441, 22);
      this.txtLinkManga.TabIndex = 1;
      // 
      // lstbxListaCapitoli
      // 
      this.lstbxListaCapitoli.FormattingEnabled = true;
      this.lstbxListaCapitoli.ItemHeight = 16;
      this.lstbxListaCapitoli.Location = new System.Drawing.Point(23, 176);
      this.lstbxListaCapitoli.Name = "lstbxListaCapitoli";
      this.lstbxListaCapitoli.Size = new System.Drawing.Size(498, 260);
      this.lstbxListaCapitoli.TabIndex = 2;
      this.lstbxListaCapitoli.SelectedIndexChanged += new System.EventHandler(this.lstbxListaCapitoli_SelectedIndexChanged);
      // 
      // lstbxListaLinkDownload
      // 
      this.lstbxListaLinkDownload.FormattingEnabled = true;
      this.lstbxListaLinkDownload.ItemHeight = 16;
      this.lstbxListaLinkDownload.Location = new System.Drawing.Point(583, 176);
      this.lstbxListaLinkDownload.Name = "lstbxListaLinkDownload";
      this.lstbxListaLinkDownload.Size = new System.Drawing.Size(437, 260);
      this.lstbxListaLinkDownload.TabIndex = 3;
      // 
      // btnScarica
      // 
      this.btnScarica.Location = new System.Drawing.Point(518, 38);
      this.btnScarica.Name = "btnScarica";
      this.btnScarica.Size = new System.Drawing.Size(107, 33);
      this.btnScarica.TabIndex = 4;
      this.btnScarica.Text = "Avvia";
      this.btnScarica.UseVisualStyleBackColor = true;
      this.btnScarica.Click += new System.EventHandler(this.btnScarica_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1047, 493);
      this.tabControl1.TabIndex = 5;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.progressBar1);
      this.tabPage1.Controls.Add(this.lstbxListaCapitoli);
      this.tabPage1.Controls.Add(this.btnScarica);
      this.tabPage1.Controls.Add(this.lstbxListaLinkDownload);
      this.tabPage1.Controls.Add(this.txtLinkManga);
      this.tabPage1.Controls.Add(this.lblNumeroCapitoli);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1039, 464);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1039, 464);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(305, 111);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(292, 47);
      this.progressBar1.TabIndex = 5;
      this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1089, 517);
      this.Controls.Add(this.tabControl1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblNumeroCapitoli;
    private System.Windows.Forms.TextBox txtLinkManga;
    private System.Windows.Forms.ListBox lstbxListaCapitoli;
    private System.Windows.Forms.ListBox lstbxListaLinkDownload;
    private System.Windows.Forms.Button btnScarica;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.ProgressBar progressBar1;
  }
}

