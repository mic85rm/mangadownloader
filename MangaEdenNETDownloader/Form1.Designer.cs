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
      this.SuspendLayout();
      // 
      // lblNumeroCapitoli
      // 
      this.lblNumeroCapitoli.AutoSize = true;
      this.lblNumeroCapitoli.Location = new System.Drawing.Point(674, 52);
      this.lblNumeroCapitoli.Name = "lblNumeroCapitoli";
      this.lblNumeroCapitoli.Size = new System.Drawing.Size(46, 17);
      this.lblNumeroCapitoli.TabIndex = 0;
      this.lblNumeroCapitoli.Text = "Numero Capitoli:";
      // 
      // txtLinkManga
      // 
      this.txtLinkManga.Location = new System.Drawing.Point(39, 47);
      this.txtLinkManga.Name = "txtLinkManga";
      this.txtLinkManga.Size = new System.Drawing.Size(441, 22);
      this.txtLinkManga.TabIndex = 1;
      // 
      // lstbxListaCapitoli
      // 
      this.lstbxListaCapitoli.FormattingEnabled = true;
      this.lstbxListaCapitoli.ItemHeight = 16;
      this.lstbxListaCapitoli.Location = new System.Drawing.Point(39, 107);
      this.lstbxListaCapitoli.Name = "lstbxListaCapitoli";
      this.lstbxListaCapitoli.Size = new System.Drawing.Size(514, 260);
      this.lstbxListaCapitoli.TabIndex = 2;
      this.lstbxListaCapitoli.SelectedIndexChanged += new System.EventHandler(this.lstbxListaCapitoli_SelectedIndexChanged);
      // 
      // lstbxListaLinkDownload
      // 
      this.lstbxListaLinkDownload.FormattingEnabled = true;
      this.lstbxListaLinkDownload.ItemHeight = 16;
      this.lstbxListaLinkDownload.Location = new System.Drawing.Point(559, 107);
      this.lstbxListaLinkDownload.Name = "lstbxListaLinkDownload";
      this.lstbxListaLinkDownload.Size = new System.Drawing.Size(437, 260);
      this.lstbxListaLinkDownload.TabIndex = 3;
      // 
      // btnScarica
      // 
      this.btnScarica.Location = new System.Drawing.Point(511, 42);
      this.btnScarica.Name = "btnScarica";
      this.btnScarica.Size = new System.Drawing.Size(107, 33);
      this.btnScarica.TabIndex = 4;
      this.btnScarica.Text = "button1";
      this.btnScarica.UseVisualStyleBackColor = true;
      this.btnScarica.Click += new System.EventHandler(this.btnScarica_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1023, 450);
      this.Controls.Add(this.btnScarica);
      this.Controls.Add(this.lstbxListaLinkDownload);
      this.Controls.Add(this.lstbxListaCapitoli);
      this.Controls.Add(this.txtLinkManga);
      this.Controls.Add(this.lblNumeroCapitoli);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblNumeroCapitoli;
    private System.Windows.Forms.TextBox txtLinkManga;
    private System.Windows.Forms.ListBox lstbxListaCapitoli;
    private System.Windows.Forms.ListBox lstbxListaLinkDownload;
    private System.Windows.Forms.Button btnScarica;
  }
}

