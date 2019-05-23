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
      this.label1 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.chkOrdinamento = new System.Windows.Forms.CheckBox();
      this.btnIndirizzoSalva = new System.Windows.Forms.Button();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.txtIndirizzoSalva = new System.Windows.Forms.TextBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1047, 493);
      this.tabControl1.TabIndex = 5;
      // 
      // tabPage1
      // 
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
      this.tabPage2.Controls.Add(this.txtIndirizzoSalva);
      this.tabPage2.Controls.Add(this.btnIndirizzoSalva);
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Controls.Add(this.numericUpDown1);
      this.tabPage2.Controls.Add(this.chkOrdinamento);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1039, 464);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(123, 95);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(42, 93);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(64, 22);
      this.numericUpDown1.TabIndex = 1;
      // 
      // chkOrdinamento
      // 
      this.chkOrdinamento.AutoSize = true;
      this.chkOrdinamento.Location = new System.Drawing.Point(42, 36);
      this.chkOrdinamento.Name = "chkOrdinamento";
      this.chkOrdinamento.Size = new System.Drawing.Size(180, 21);
      this.chkOrdinamento.TabIndex = 0;
      this.chkOrdinamento.Text = "Ordinamento Crescente";
      this.chkOrdinamento.UseVisualStyleBackColor = true;
      this.chkOrdinamento.CheckedChanged += new System.EventHandler(this.chkOrdinamento_CheckedChanged);
      // 
      // btnIndirizzoSalva
      // 
      this.btnIndirizzoSalva.Location = new System.Drawing.Point(42, 163);
      this.btnIndirizzoSalva.Name = "btnIndirizzoSalva";
      this.btnIndirizzoSalva.Size = new System.Drawing.Size(131, 36);
      this.btnIndirizzoSalva.TabIndex = 3;
      this.btnIndirizzoSalva.Text = "Apri";
      this.btnIndirizzoSalva.UseVisualStyleBackColor = true;
      this.btnIndirizzoSalva.Click += new System.EventHandler(this.btnIndirizzoSalva_Click);
      // 
      // txtIndirizzoSalva
      // 
      this.txtIndirizzoSalva.Enabled = false;
      this.txtIndirizzoSalva.Location = new System.Drawing.Point(196, 170);
      this.txtIndirizzoSalva.Name = "txtIndirizzoSalva";
      this.txtIndirizzoSalva.Size = new System.Drawing.Size(803, 22);
      this.txtIndirizzoSalva.TabIndex = 4;
      this.txtIndirizzoSalva.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(1039, 464);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
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
      this.Text = "MangaEdenNETDownloader";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
    private System.Windows.Forms.CheckBox chkOrdinamento;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.Button btnIndirizzoSalva;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TextBox txtIndirizzoSalva;
    private System.Windows.Forms.TabPage tabPage3;
  }
}

