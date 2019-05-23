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
      this.btnScarica = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.label1 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.chklstbxListaCapitoli = new System.Windows.Forms.CheckedListBox();
      this.btnSelectAll = new System.Windows.Forms.Button();
      this.btnDeselectAll = new System.Windows.Forms.Button();
      this.chkOrdinamento = new System.Windows.Forms.CheckBox();
      this.btnIndirizzoSalva = new System.Windows.Forms.Button();
      this.txtIndirizzoSalva = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lblStato = new System.Windows.Forms.Label();
      this.btnConfermaDownload = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // lblNumeroCapitoli
      // 
      this.lblNumeroCapitoli.AutoSize = true;
      this.lblNumeroCapitoli.Location = new System.Drawing.Point(8, 438);
      this.lblNumeroCapitoli.Name = "lblNumeroCapitoli";
      this.lblNumeroCapitoli.Size = new System.Drawing.Size(112, 17);
      this.lblNumeroCapitoli.TabIndex = 0;
      this.lblNumeroCapitoli.Text = "Numero Capitoli:";
      // 
      // txtLinkManga
      // 
      this.txtLinkManga.Location = new System.Drawing.Point(28, 24);
      this.txtLinkManga.Name = "txtLinkManga";
      this.txtLinkManga.Size = new System.Drawing.Size(441, 22);
      this.txtLinkManga.TabIndex = 1;
      // 
      // btnScarica
      // 
      this.btnScarica.Location = new System.Drawing.Point(517, 14);
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
      this.tabControl1.Size = new System.Drawing.Size(1047, 645);
      this.tabControl1.TabIndex = 5;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.btnConfermaDownload);
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Controls.Add(this.button1);
      this.tabPage1.Controls.Add(this.txtIndirizzoSalva);
      this.tabPage1.Controls.Add(this.btnIndirizzoSalva);
      this.tabPage1.Controls.Add(this.chkOrdinamento);
      this.tabPage1.Controls.Add(this.btnDeselectAll);
      this.tabPage1.Controls.Add(this.btnSelectAll);
      this.tabPage1.Controls.Add(this.chklstbxListaCapitoli);
      this.tabPage1.Controls.Add(this.btnScarica);
      this.tabPage1.Controls.Add(this.txtLinkManga);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1039, 616);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Controls.Add(this.numericUpDown1);
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
      // chklstbxListaCapitoli
      // 
      this.chklstbxListaCapitoli.FormattingEnabled = true;
      this.chklstbxListaCapitoli.Location = new System.Drawing.Point(395, 59);
      this.chklstbxListaCapitoli.Name = "chklstbxListaCapitoli";
      this.chklstbxListaCapitoli.Size = new System.Drawing.Size(616, 463);
      this.chklstbxListaCapitoli.TabIndex = 5;
      // 
      // btnSelectAll
      // 
      this.btnSelectAll.Enabled = false;
      this.btnSelectAll.Location = new System.Drawing.Point(395, 524);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new System.Drawing.Size(143, 33);
      this.btnSelectAll.TabIndex = 6;
      this.btnSelectAll.Text = "Seleziona Tutto";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
      // 
      // btnDeselectAll
      // 
      this.btnDeselectAll.Enabled = false;
      this.btnDeselectAll.Location = new System.Drawing.Point(544, 524);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new System.Drawing.Size(143, 33);
      this.btnDeselectAll.TabIndex = 7;
      this.btnDeselectAll.Text = "Deseleziona Tutto";
      this.btnDeselectAll.UseVisualStyleBackColor = true;
      this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
      // 
      // chkOrdinamento
      // 
      this.chkOrdinamento.AutoSize = true;
      this.chkOrdinamento.Location = new System.Drawing.Point(33, 531);
      this.chkOrdinamento.Name = "chkOrdinamento";
      this.chkOrdinamento.Size = new System.Drawing.Size(180, 21);
      this.chkOrdinamento.TabIndex = 8;
      this.chkOrdinamento.Text = "Ordinamento Crescente";
      this.chkOrdinamento.UseVisualStyleBackColor = true;
      this.chkOrdinamento.Visible = false;
      this.chkOrdinamento.CheckedChanged += new System.EventHandler(this.chkOrdinamento_CheckedChanged_1);
      // 
      // btnIndirizzoSalva
      // 
      this.btnIndirizzoSalva.Location = new System.Drawing.Point(28, 558);
      this.btnIndirizzoSalva.Name = "btnIndirizzoSalva";
      this.btnIndirizzoSalva.Size = new System.Drawing.Size(131, 36);
      this.btnIndirizzoSalva.TabIndex = 9;
      this.btnIndirizzoSalva.Text = "Apri";
      this.btnIndirizzoSalva.UseVisualStyleBackColor = true;
      // 
      // txtIndirizzoSalva
      // 
      this.txtIndirizzoSalva.Enabled = false;
      this.txtIndirizzoSalva.Location = new System.Drawing.Point(165, 572);
      this.txtIndirizzoSalva.Name = "txtIndirizzoSalva";
      this.txtIndirizzoSalva.Size = new System.Drawing.Size(539, 22);
      this.txtIndirizzoSalva.TabIndex = 10;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(645, 15);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(171, 31);
      this.button1.TabIndex = 11;
      this.button1.Text = "Nuovo Download";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblStato);
      this.groupBox1.Controls.Add(this.pictureBox1);
      this.groupBox1.Controls.Add(this.lblNumeroCapitoli);
      this.groupBox1.Location = new System.Drawing.Point(22, 52);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(367, 473);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Titolo Manga";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(11, 21);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(300, 414);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // lblStato
      // 
      this.lblStato.AutoSize = true;
      this.lblStato.Location = new System.Drawing.Point(196, 438);
      this.lblStato.Name = "lblStato";
      this.lblStato.Size = new System.Drawing.Size(45, 17);
      this.lblStato.TabIndex = 4;
      this.lblStato.Text = "Stato:";
      // 
      // btnConfermaDownload
      // 
      this.btnConfermaDownload.Enabled = false;
      this.btnConfermaDownload.Location = new System.Drawing.Point(843, 528);
      this.btnConfermaDownload.Name = "btnConfermaDownload";
      this.btnConfermaDownload.Size = new System.Drawing.Size(168, 45);
      this.btnConfermaDownload.TabIndex = 13;
      this.btnConfermaDownload.Text = "Download";
      this.btnConfermaDownload.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1080, 661);
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
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblNumeroCapitoli;
    private System.Windows.Forms.TextBox txtLinkManga;
    private System.Windows.Forms.Button btnScarica;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.CheckedListBox chklstbxListaCapitoli;
    private System.Windows.Forms.Button btnDeselectAll;
    private System.Windows.Forms.Button btnSelectAll;
    private System.Windows.Forms.CheckBox chkOrdinamento;
    private System.Windows.Forms.TextBox txtIndirizzoSalva;
    private System.Windows.Forms.Button btnIndirizzoSalva;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label lblStato;
    private System.Windows.Forms.Button btnConfermaDownload;
  }
}

