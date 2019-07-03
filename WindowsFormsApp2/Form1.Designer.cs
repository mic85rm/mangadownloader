using System.Windows.Forms;

namespace WindowsFormsApp2
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox7 = new System.Windows.Forms.GroupBox();
      this.txtTrama = new System.Windows.Forms.TextBox();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.chklstbxListaCapitoli = new System.Windows.Forms.CheckedListBox();
      this.btnSelectAll = new System.Windows.Forms.Button();
      this.btnDeselectAll = new System.Windows.Forms.Button();
      this.btnConfermaDownload = new System.Windows.Forms.Button();
      this.cbxListaManga = new System.Windows.Forms.ComboBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.lblNumeroElencoMangaTrovati = new System.Windows.Forms.Label();
      this.txtCerca = new System.Windows.Forms.TextBox();
      this.btnCerca = new System.Windows.Forms.Button();
      this.lstboxManga = new System.Windows.Forms.ListBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.groupBox10 = new System.Windows.Forms.GroupBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.btnModifica = new System.Windows.Forms.Button();
      this.groupBox9 = new System.Windows.Forms.GroupBox();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.groupBox8 = new System.Windows.Forms.GroupBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.lblTempoStimatoDownload = new System.Windows.Forms.Label();
      this.lblPerc = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStopDownload = new System.Windows.Forms.Button();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtIndirizzoCartellaSalvataggio = new System.Windows.Forms.TextBox();
      this.btnApriCartellaSalvataggio = new System.Windows.Forms.Button();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.bgwDownloadAsincrono = new System.ComponentModel.BackgroundWorker();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.bgwCreazioneListaDownload = new System.ComponentModel.BackgroundWorker();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.lblFileScaricati = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox6.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox10.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.groupBox9.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.groupBox7);
      this.groupBox1.Controls.Add(this.groupBox5);
      this.groupBox1.Controls.Add(this.groupBox6);
      this.groupBox1.Location = new System.Drawing.Point(427, 16);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(967, 684);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Anteprima Manga";
      // 
      // groupBox7
      // 
      this.groupBox7.Controls.Add(this.txtTrama);
      this.groupBox7.Location = new System.Drawing.Point(6, 21);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new System.Drawing.Size(930, 154);
      this.groupBox7.TabIndex = 1;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Trama";
      this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
      // 
      // txtTrama
      // 
      this.txtTrama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtTrama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtTrama.Location = new System.Drawing.Point(17, 21);
      this.txtTrama.Multiline = true;
      this.txtTrama.Name = "txtTrama";
      this.txtTrama.ReadOnly = true;
      this.txtTrama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtTrama.Size = new System.Drawing.Size(884, 127);
      this.txtTrama.TabIndex = 1;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.pictureBox1);
      this.groupBox5.Location = new System.Drawing.Point(6, 181);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(300, 389);
      this.groupBox5.TabIndex = 8;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Copertina ";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
      this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
      this.pictureBox1.Location = new System.Drawing.Point(16, 21);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(270, 352);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.chklstbxListaCapitoli);
      this.groupBox6.Controls.Add(this.btnSelectAll);
      this.groupBox6.Controls.Add(this.btnDeselectAll);
      this.groupBox6.Location = new System.Drawing.Point(318, 181);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(618, 485);
      this.groupBox6.TabIndex = 9;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Capitoli";
      // 
      // chklstbxListaCapitoli
      // 
      this.chklstbxListaCapitoli.CheckOnClick = true;
      this.chklstbxListaCapitoli.FormattingEnabled = true;
      this.chklstbxListaCapitoli.Location = new System.Drawing.Point(12, 18);
      this.chklstbxListaCapitoli.Name = "chklstbxListaCapitoli";
      this.chklstbxListaCapitoli.Size = new System.Drawing.Size(600, 429);
      this.chklstbxListaCapitoli.TabIndex = 4;
      this.chklstbxListaCapitoli.SelectedIndexChanged += new System.EventHandler(this.chklstbxListaCapitoli_SelectedIndexChanged);
      // 
      // btnSelectAll
      // 
      this.btnSelectAll.Location = new System.Drawing.Point(281, 453);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new System.Drawing.Size(140, 26);
      this.btnSelectAll.TabIndex = 6;
      this.btnSelectAll.Text = "Seleziona Tutto";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
      // 
      // btnDeselectAll
      // 
      this.btnDeselectAll.Location = new System.Drawing.Point(439, 453);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new System.Drawing.Size(173, 25);
      this.btnDeselectAll.TabIndex = 7;
      this.btnDeselectAll.Text = "Deseleziona Tutto";
      this.btnDeselectAll.UseVisualStyleBackColor = true;
      this.btnDeselectAll.Click += new System.EventHandler(this.BtnDeselectAll_Click);
      // 
      // btnConfermaDownload
      // 
      this.btnConfermaDownload.Enabled = false;
      this.btnConfermaDownload.Location = new System.Drawing.Point(433, 723);
      this.btnConfermaDownload.Name = "btnConfermaDownload";
      this.btnConfermaDownload.Size = new System.Drawing.Size(958, 60);
      this.btnConfermaDownload.TabIndex = 5;
      this.btnConfermaDownload.Text = "Download";
      this.btnConfermaDownload.UseVisualStyleBackColor = true;
      this.btnConfermaDownload.Click += new System.EventHandler(this.btnConfermaDownload_Click);
      // 
      // cbxListaManga
      // 
      this.cbxListaManga.FormattingEnabled = true;
      this.cbxListaManga.Location = new System.Drawing.Point(6, 0);
      this.cbxListaManga.Name = "cbxListaManga";
      this.cbxListaManga.Size = new System.Drawing.Size(278, 24);
      this.cbxListaManga.TabIndex = 3;
      this.cbxListaManga.Visible = false;
      this.cbxListaManga.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      this.cbxListaManga.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
      this.cbxListaManga.TextChanged += new System.EventHandler(this.CbxListaManga_TextChanged);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1405, 830);
      this.tabControl1.TabIndex = 4;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Controls.Add(this.groupBox4);
      this.tabPage1.Controls.Add(this.btnConfermaDownload);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1397, 801);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.lblNumeroElencoMangaTrovati);
      this.groupBox4.Controls.Add(this.txtCerca);
      this.groupBox4.Controls.Add(this.btnCerca);
      this.groupBox4.Controls.Add(this.lstboxManga);
      this.groupBox4.Controls.Add(this.cbxListaManga);
      this.groupBox4.Location = new System.Drawing.Point(6, 6);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(412, 777);
      this.groupBox4.TabIndex = 6;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Lista Manga";
      // 
      // lblNumeroElencoMangaTrovati
      // 
      this.lblNumeroElencoMangaTrovati.AutoSize = true;
      this.lblNumeroElencoMangaTrovati.Location = new System.Drawing.Point(47, 77);
      this.lblNumeroElencoMangaTrovati.Name = "lblNumeroElencoMangaTrovati";
      this.lblNumeroElencoMangaTrovati.Size = new System.Drawing.Size(99, 17);
      this.lblNumeroElencoMangaTrovati.TabIndex = 12;
      this.lblNumeroElencoMangaTrovati.Text = "numeromanga";
      // 
      // txtCerca
      // 
      this.txtCerca.Location = new System.Drawing.Point(16, 40);
      this.txtCerca.Name = "txtCerca";
      this.txtCerca.Size = new System.Drawing.Size(274, 22);
      this.txtCerca.TabIndex = 11;
      this.txtCerca.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // btnCerca
      // 
      this.btnCerca.Enabled = false;
      this.btnCerca.Location = new System.Drawing.Point(296, 31);
      this.btnCerca.Name = "btnCerca";
      this.btnCerca.Size = new System.Drawing.Size(94, 41);
      this.btnCerca.TabIndex = 10;
      this.btnCerca.Text = "Cerca";
      this.btnCerca.UseVisualStyleBackColor = true;
      this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
      // 
      // lstboxManga
      // 
      this.lstboxManga.FormattingEnabled = true;
      this.lstboxManga.ItemHeight = 16;
      this.lstboxManga.Location = new System.Drawing.Point(6, 108);
      this.lstboxManga.Name = "lstboxManga";
      this.lstboxManga.Size = new System.Drawing.Size(398, 628);
      this.lstboxManga.TabIndex = 9;
      this.lstboxManga.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.groupBox10);
      this.tabPage2.Controls.Add(this.groupBox9);
      this.tabPage2.Controls.Add(this.groupBox8);
      this.tabPage2.Controls.Add(this.groupBox3);
      this.tabPage2.Controls.Add(this.groupBox2);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1397, 801);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // groupBox10
      // 
      this.groupBox10.Controls.Add(this.dataGridView1);
      this.groupBox10.Controls.Add(this.btnModifica);
      this.groupBox10.Location = new System.Drawing.Point(54, 197);
      this.groupBox10.Name = "groupBox10";
      this.groupBox10.Size = new System.Drawing.Size(957, 356);
      this.groupBox10.TabIndex = 12;
      this.groupBox10.TabStop = false;
      this.groupBox10.Text = "Info Download";
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(10, 21);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.RowTemplate.Height = 24;
      this.dataGridView1.Size = new System.Drawing.Size(927, 274);
      this.dataGridView1.TabIndex = 1;
      // 
      // btnModifica
      // 
      this.btnModifica.Enabled = false;
      this.btnModifica.Location = new System.Drawing.Point(813, 301);
      this.btnModifica.Name = "btnModifica";
      this.btnModifica.Size = new System.Drawing.Size(124, 40);
      this.btnModifica.TabIndex = 0;
      this.btnModifica.Text = "Modifica";
      this.btnModifica.UseVisualStyleBackColor = true;
      this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
      // 
      // groupBox9
      // 
      this.groupBox9.Controls.Add(this.richTextBox1);
      this.groupBox9.Location = new System.Drawing.Point(54, 115);
      this.groupBox9.Name = "groupBox9";
      this.groupBox9.Size = new System.Drawing.Size(572, 76);
      this.groupBox9.TabIndex = 11;
      this.groupBox9.TabStop = false;
      this.groupBox9.Text = "groupBox9";
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(16, 31);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(127, 30);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      // 
      // groupBox8
      // 
      this.groupBox8.Controls.Add(this.checkBox3);
      this.groupBox8.Controls.Add(this.checkBox2);
      this.groupBox8.Controls.Add(this.checkBox1);
      this.groupBox8.Location = new System.Drawing.Point(673, 24);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new System.Drawing.Size(332, 76);
      this.groupBox8.TabIndex = 10;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Formato Salvataggio";
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point(39, 33);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(53, 21);
      this.checkBox3.TabIndex = 2;
      this.checkBox3.Text = ".jpg";
      this.checkBox3.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(138, 33);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(52, 21);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = ".zip";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(233, 33);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(56, 21);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = ".cbz";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.lblFileScaricati);
      this.groupBox3.Controls.Add(this.lblTempoStimatoDownload);
      this.groupBox3.Controls.Add(this.lblPerc);
      this.groupBox3.Controls.Add(this.btnStart);
      this.groupBox3.Controls.Add(this.btnStopDownload);
      this.groupBox3.Controls.Add(this.progressBar);
      this.groupBox3.Location = new System.Drawing.Point(41, 559);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(964, 189);
      this.groupBox3.TabIndex = 9;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Download File";
      // 
      // lblTempoStimatoDownload
      // 
      this.lblTempoStimatoDownload.AutoSize = true;
      this.lblTempoStimatoDownload.Location = new System.Drawing.Point(539, 30);
      this.lblTempoStimatoDownload.Name = "lblTempoStimatoDownload";
      this.lblTempoStimatoDownload.Size = new System.Drawing.Size(46, 17);
      this.lblTempoStimatoDownload.TabIndex = 6;
      this.lblTempoStimatoDownload.Text = "label1";
      this.lblTempoStimatoDownload.Click += new System.EventHandler(this.lblTempoStimatoDownload_Click);
      // 
      // lblPerc
      // 
      this.lblPerc.AutoSize = true;
      this.lblPerc.Location = new System.Drawing.Point(26, 40);
      this.lblPerc.Name = "lblPerc";
      this.lblPerc.Size = new System.Drawing.Size(16, 17);
      this.lblPerc.TabIndex = 0;
      this.lblPerc.Text = "a";
      // 
      // btnStart
      // 
      this.btnStart.Enabled = false;
      this.btnStart.Location = new System.Drawing.Point(23, 107);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(220, 45);
      this.btnStart.TabIndex = 5;
      this.btnStart.Text = "Inizia Download";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStartDownload_Click);
      // 
      // btnStopDownload
      // 
      this.btnStopDownload.Enabled = false;
      this.btnStopDownload.Location = new System.Drawing.Point(249, 107);
      this.btnStopDownload.Name = "btnStopDownload";
      this.btnStopDownload.Size = new System.Drawing.Size(197, 45);
      this.btnStopDownload.TabIndex = 4;
      this.btnStopDownload.Text = "Annulla";
      this.btnStopDownload.UseVisualStyleBackColor = true;
      this.btnStopDownload.Click += new System.EventHandler(this.btoCancel_Click);
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(23, 60);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(918, 41);
      this.progressBar.TabIndex = 3;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtIndirizzoCartellaSalvataggio);
      this.groupBox2.Controls.Add(this.btnApriCartellaSalvataggio);
      this.groupBox2.Location = new System.Drawing.Point(54, 21);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(566, 79);
      this.groupBox2.TabIndex = 8;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Cartella Download";
      // 
      // txtIndirizzoCartellaSalvataggio
      // 
      this.txtIndirizzoCartellaSalvataggio.Location = new System.Drawing.Point(138, 38);
      this.txtIndirizzoCartellaSalvataggio.Name = "txtIndirizzoCartellaSalvataggio";
      this.txtIndirizzoCartellaSalvataggio.Size = new System.Drawing.Size(410, 22);
      this.txtIndirizzoCartellaSalvataggio.TabIndex = 7;
      // 
      // btnApriCartellaSalvataggio
      // 
      this.btnApriCartellaSalvataggio.Location = new System.Drawing.Point(6, 30);
      this.btnApriCartellaSalvataggio.Name = "btnApriCartellaSalvataggio";
      this.btnApriCartellaSalvataggio.Size = new System.Drawing.Size(116, 30);
      this.btnApriCartellaSalvataggio.TabIndex = 6;
      this.btnApriCartellaSalvataggio.Text = "Apri";
      this.btnApriCartellaSalvataggio.UseVisualStyleBackColor = true;
      this.btnApriCartellaSalvataggio.Click += new System.EventHandler(this.btnApriCartellaSalvataggio_Click);
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(1397, 801);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // bgwDownloadAsincrono
      // 
      this.bgwDownloadAsincrono.WorkerSupportsCancellation = true;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lblFileScaricati
      // 
      this.lblFileScaricati.AutoSize = true;
      this.lblFileScaricati.Location = new System.Drawing.Point(723, 31);
      this.lblFileScaricati.Name = "lblFileScaricati";
      this.lblFileScaricati.Size = new System.Drawing.Size(46, 17);
      this.lblFileScaricati.TabIndex = 7;
      this.lblFileScaricati.Text = "label1";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1429, 853);
      this.Controls.Add(this.tabControl1);
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "MangaEdenDownloader";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.groupBox5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox6.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.groupBox10.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.groupBox9.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private GroupBox groupBox1;
    private PictureBox pictureBox1;
    private ComboBox cbxListaManga;
    private CheckedListBox chklstbxListaCapitoli;
    private Button btnConfermaDownload;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private Button btnDeselectAll;
    private Button btnSelectAll;
    private ProgressBar progressBar;
    private Label lblPerc;
    private Button btnStart;
    private Button btnStopDownload;
    private System.ComponentModel.BackgroundWorker bgwDownloadAsincrono;
    private TextBox txtIndirizzoCartellaSalvataggio;
    private Button btnApriCartellaSalvataggio;
    private FolderBrowserDialog folderBrowserDialog1;
    private GroupBox groupBox3;
    private GroupBox groupBox2;
    private GroupBox groupBox4;
    private TabPage tabPage3;
    private GroupBox groupBox6;
    private GroupBox groupBox5;
    private GroupBox groupBox7;
    private GroupBox groupBox10;
    private GroupBox groupBox9;
    private RichTextBox richTextBox1;
    private GroupBox groupBox8;
    private CheckBox checkBox3;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
    private TextBox txtTrama;
    public System.ComponentModel.BackgroundWorker bgwCreazioneListaDownload;
    private Timer timer1;
    private DataGridView dataGridView1;
    private Button btnModifica;
    private Label lblTempoStimatoDownload;
    private ListBox lstboxManga;
    private TextBox txtCerca;
    private Button btnCerca;
    private Label lblNumeroElencoMangaTrovati;
    private Label lblFileScaricati;
  }
}

