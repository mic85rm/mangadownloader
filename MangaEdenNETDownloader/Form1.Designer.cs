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
            this.btnIndirizzoSalva = new System.Windows.Forms.Button();
            this.txtIndirizzoSalva = new System.Windows.Forms.TextBox();
            this.chklstbxListaCapitoli = new System.Windows.Forms.CheckedListBox();
            this.btnConfermaDownload = new System.Windows.Forms.Button();
            this.TitoloManga = new System.Windows.Forms.GroupBox();
            this.lblStato = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNuovaAnalisi = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.twCodaDownload = new System.Windows.Forms.TreeView();
            this.lblFatto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInizia = new System.Windows.Forms.Button();
            this.lblDownload = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TitoloManga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage3.SuspendLayout();
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
            this.txtLinkManga.Size = new System.Drawing.Size(708, 22);
            this.txtLinkManga.TabIndex = 1;
            this.txtLinkManga.TextChanged += new System.EventHandler(this.txtLinkManga_TextChanged);
            // 
            // btnScarica
            // 
            this.btnScarica.Location = new System.Drawing.Point(759, 15);
            this.btnScarica.Name = "btnScarica";
            this.btnScarica.Size = new System.Drawing.Size(107, 33);
            this.btnScarica.TabIndex = 4;
            this.btnScarica.Text = "Avvia Analisi";
            this.btnScarica.UseVisualStyleBackColor = true;
            this.btnScarica.Click += new System.EventHandler(this.BtnScarica_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1249, 645);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.btnIndirizzoSalva);
            this.tabPage1.Controls.Add(this.txtIndirizzoSalva);
            this.tabPage1.Controls.Add(this.chklstbxListaCapitoli);
            this.tabPage1.Controls.Add(this.btnConfermaDownload);
            this.tabPage1.Controls.Add(this.TitoloManga);
            this.tabPage1.Controls.Add(this.btnNuovaAnalisi);
            this.tabPage1.Controls.Add(this.btnDeselectAll);
            this.tabPage1.Controls.Add(this.btnSelectAll);
            this.tabPage1.Controls.Add(this.btnScarica);
            this.tabPage1.Controls.Add(this.txtLinkManga);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1241, 616);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnIndirizzoSalva
            // 
            this.btnIndirizzoSalva.Location = new System.Drawing.Point(742, 60);
            this.btnIndirizzoSalva.Name = "btnIndirizzoSalva";
            this.btnIndirizzoSalva.Size = new System.Drawing.Size(131, 27);
            this.btnIndirizzoSalva.TabIndex = 16;
            this.btnIndirizzoSalva.Text = "..";
            this.btnIndirizzoSalva.UseVisualStyleBackColor = true;
            this.btnIndirizzoSalva.Click += new System.EventHandler(this.btnIndirizzoSalva_Click);
            // 
            // txtIndirizzoSalva
            // 
            this.txtIndirizzoSalva.Enabled = false;
            this.txtIndirizzoSalva.Location = new System.Drawing.Point(28, 60);
            this.txtIndirizzoSalva.Name = "txtIndirizzoSalva";
            this.txtIndirizzoSalva.Size = new System.Drawing.Size(708, 22);
            this.txtIndirizzoSalva.TabIndex = 15;
            // 
            // chklstbxListaCapitoli
            // 
            this.chklstbxListaCapitoli.CheckOnClick = true;
            this.chklstbxListaCapitoli.FormattingEnabled = true;
            this.chklstbxListaCapitoli.Location = new System.Drawing.Point(366, 98);
            this.chklstbxListaCapitoli.Name = "chklstbxListaCapitoli";
            this.chklstbxListaCapitoli.Size = new System.Drawing.Size(851, 463);
            this.chklstbxListaCapitoli.TabIndex = 14;
            this.chklstbxListaCapitoli.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstbxListaCapitoli_ItemCheck);
            this.chklstbxListaCapitoli.SelectedIndexChanged += new System.EventHandler(this.chklstbxListaCapitoli_SelectedIndexChanged);
            // 
            // btnConfermaDownload
            // 
            this.btnConfermaDownload.Enabled = false;
            this.btnConfermaDownload.Location = new System.Drawing.Point(785, 567);
            this.btnConfermaDownload.Name = "btnConfermaDownload";
            this.btnConfermaDownload.Size = new System.Drawing.Size(230, 43);
            this.btnConfermaDownload.TabIndex = 13;
            this.btnConfermaDownload.Text = "Download";
            this.btnConfermaDownload.UseVisualStyleBackColor = true;
            this.btnConfermaDownload.Click += new System.EventHandler(this.BtnConfermaDownload_Click);
            // 
            // TitoloManga
            // 
            this.TitoloManga.Controls.Add(this.lblStato);
            this.TitoloManga.Controls.Add(this.pictureBox1);
            this.TitoloManga.Controls.Add(this.lblNumeroCapitoli);
            this.TitoloManga.Location = new System.Drawing.Point(28, 88);
            this.TitoloManga.Name = "TitoloManga";
            this.TitoloManga.Size = new System.Drawing.Size(332, 473);
            this.TitoloManga.TabIndex = 12;
            this.TitoloManga.TabStop = false;
            this.TitoloManga.Text = "Titolo Manga";
            this.TitoloManga.Enter += new System.EventHandler(this.TitoloManga_Enter);
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(150, 438);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(45, 17);
            this.lblStato.TabIndex = 4;
            this.lblStato.Text = "Stato:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 414);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnNuovaAnalisi
            // 
            this.btnNuovaAnalisi.Location = new System.Drawing.Point(872, 16);
            this.btnNuovaAnalisi.Name = "btnNuovaAnalisi";
            this.btnNuovaAnalisi.Size = new System.Drawing.Size(131, 31);
            this.btnNuovaAnalisi.TabIndex = 11;
            this.btnNuovaAnalisi.Text = "Nuova Analisi";
            this.btnNuovaAnalisi.UseVisualStyleBackColor = true;
            this.btnNuovaAnalisi.Click += new System.EventHandler(this.btnNuovaAnalisi_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Enabled = false;
            this.btnDeselectAll.Location = new System.Drawing.Point(515, 567);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(143, 33);
            this.btnDeselectAll.TabIndex = 7;
            this.btnDeselectAll.Text = "Deseleziona Tutto";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Location = new System.Drawing.Point(366, 567);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(143, 33);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Text = "Seleziona Tutto";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.twCodaDownload);
            this.tabPage2.Controls.Add(this.lblFatto);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnInizia);
            this.tabPage2.Controls.Add(this.lblDownload);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1241, 616);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // twCodaDownload
            // 
            this.twCodaDownload.Location = new System.Drawing.Point(27, 100);
            this.twCodaDownload.Name = "twCodaDownload";
            this.twCodaDownload.Size = new System.Drawing.Size(949, 324);
            this.twCodaDownload.TabIndex = 21;
            // 
            // lblFatto
            // 
            this.lblFatto.AutoSize = true;
            this.lblFatto.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFatto.Location = new System.Drawing.Point(387, 518);
            this.lblFatto.Name = "lblFatto";
            this.lblFatto.Size = new System.Drawing.Size(228, 69);
            this.lblFatto.TabIndex = 20;
            this.lblFatto.Text = "FATTO";
            this.lblFatto.Visible = false;
            this.lblFatto.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Coda Download";
            // 
            // btnInizia
            // 
            this.btnInizia.Enabled = false;
            this.btnInizia.Location = new System.Drawing.Point(385, 430);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(230, 64);
            this.btnInizia.TabIndex = 17;
            this.btnInizia.Text = "Inizia";
            this.btnInizia.UseVisualStyleBackColor = true;
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(39, 518);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(138, 17);
            this.lblDownload.TabIndex = 14;
            this.lblDownload.Text = "Sto scaricando il file ";
            this.lblDownload.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(42, 549);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(925, 52);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(921, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(839, 41);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 22);
            this.numericUpDown1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1241, 616);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(363, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(914, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1044, 576);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 34);
            this.button3.TabIndex = 17;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 661);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MangaEdenNETDownloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TitoloManga.ResumeLayout(false);
            this.TitoloManga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnNuovaAnalisi;
        private System.Windows.Forms.GroupBox TitoloManga;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.Button btnConfermaDownload;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chklstbxListaCapitoli;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFatto;
        private System.Windows.Forms.TreeView twCodaDownload;
        private System.Windows.Forms.Button btnIndirizzoSalva;
        private System.Windows.Forms.TextBox txtIndirizzoSalva;
        private System.Windows.Forms.Button button3;
    }
}

