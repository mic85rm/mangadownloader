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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.chklstbxListaCapitoli = new System.Windows.Forms.CheckedListBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnConfermaDownload = new System.Windows.Forms.Button();
      this.cbxListaManga = new System.Windows.Forms.ComboBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.button4 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.labelSpeed = new System.Windows.Forms.Label();
      this.labelDownloaded = new System.Windows.Forms.Label();
      this.labelPerc = new System.Windows.Forms.Label();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.button5 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button3);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.chklstbxListaCapitoli);
      this.groupBox1.Controls.Add(this.pictureBox1);
      this.groupBox1.Location = new System.Drawing.Point(6, 53);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(702, 460);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(494, 412);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(173, 25);
      this.button3.TabIndex = 7;
      this.button3.Text = "Deseleziona Tutto";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.BtnDeselectAll_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(299, 412);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(140, 26);
      this.button2.TabIndex = 6;
      this.button2.Text = "Seleziona Tutto";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.BtnSelectAll_Click);
      // 
      // chklstbxListaCapitoli
      // 
      this.chklstbxListaCapitoli.CheckOnClick = true;
      this.chklstbxListaCapitoli.FormattingEnabled = true;
      this.chklstbxListaCapitoli.Location = new System.Drawing.Point(299, 40);
      this.chklstbxListaCapitoli.Name = "chklstbxListaCapitoli";
      this.chklstbxListaCapitoli.Size = new System.Drawing.Size(368, 361);
      this.chklstbxListaCapitoli.TabIndex = 4;
      this.chklstbxListaCapitoli.SelectedIndexChanged += new System.EventHandler(this.chklstbxListaCapitoli_SelectedIndexChanged);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(26, 41);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(258, 360);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // btnConfermaDownload
      // 
      this.btnConfermaDownload.Enabled = false;
      this.btnConfermaDownload.Location = new System.Drawing.Point(535, 9);
      this.btnConfermaDownload.Name = "btnConfermaDownload";
      this.btnConfermaDownload.Size = new System.Drawing.Size(159, 35);
      this.btnConfermaDownload.TabIndex = 5;
      this.btnConfermaDownload.Text = "Download";
      this.btnConfermaDownload.UseVisualStyleBackColor = true;
      this.btnConfermaDownload.Click += new System.EventHandler(this.btnConfermaDownload_Click);
      // 
      // cbxListaManga
      // 
      this.cbxListaManga.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.cbxListaManga.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cbxListaManga.FormattingEnabled = true;
      this.cbxListaManga.Location = new System.Drawing.Point(29, 20);
      this.cbxListaManga.Name = "cbxListaManga";
      this.cbxListaManga.Size = new System.Drawing.Size(429, 24);
      this.cbxListaManga.TabIndex = 3;
      this.cbxListaManga.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      this.cbxListaManga.TextChanged += new System.EventHandler(this.CbxListaManga_TextChanged);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(740, 567);
      this.tabControl1.TabIndex = 4;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.cbxListaManga);
      this.tabPage1.Controls.Add(this.btnConfermaDownload);
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(732, 538);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.textBox1);
      this.tabPage2.Controls.Add(this.button5);
      this.tabPage2.Controls.Add(this.button4);
      this.tabPage2.Controls.Add(this.button1);
      this.tabPage2.Controls.Add(this.progressBar);
      this.tabPage2.Controls.Add(this.labelSpeed);
      this.tabPage2.Controls.Add(this.labelDownloaded);
      this.tabPage2.Controls.Add(this.labelPerc);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(732, 538);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(147, 405);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(220, 45);
      this.button4.TabIndex = 5;
      this.button4.Text = "button4";
      this.button4.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(454, 412);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(197, 39);
      this.button1.TabIndex = 4;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(263, 307);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(218, 41);
      this.progressBar.TabIndex = 3;
      // 
      // labelSpeed
      // 
      this.labelSpeed.AutoSize = true;
      this.labelSpeed.Location = new System.Drawing.Point(387, 232);
      this.labelSpeed.Name = "labelSpeed";
      this.labelSpeed.Size = new System.Drawing.Size(46, 17);
      this.labelSpeed.TabIndex = 2;
      this.labelSpeed.Text = "label3";
      // 
      // labelDownloaded
      // 
      this.labelDownloaded.AutoSize = true;
      this.labelDownloaded.Location = new System.Drawing.Point(377, 156);
      this.labelDownloaded.Name = "labelDownloaded";
      this.labelDownloaded.Size = new System.Drawing.Size(46, 17);
      this.labelDownloaded.TabIndex = 1;
      this.labelDownloaded.Text = "label2";
      // 
      // labelPerc
      // 
      this.labelPerc.AutoSize = true;
      this.labelPerc.Location = new System.Drawing.Point(381, 90);
      this.labelPerc.Name = "labelPerc";
      this.labelPerc.Size = new System.Drawing.Size(46, 17);
      this.labelPerc.TabIndex = 0;
      this.labelPerc.Text = "label1";
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerSupportsCancellation = true;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(34, 32);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(116, 30);
      this.button5.TabIndex = 6;
      this.button5.Text = "button5";
      this.button5.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(176, 32);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(251, 22);
      this.textBox1.TabIndex = 7;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(782, 584);
      this.Controls.Add(this.tabControl1);
      this.Name = "Form1";
      this.Text = "MangaEdenDownloader";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
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
    private Button button3;
    private Button button2;
    private ProgressBar progressBar;
    private Label labelSpeed;
    private Label labelDownloaded;
    private Label labelPerc;
    private Button button4;
    private Button button1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private TextBox textBox1;
    private Button button5;
    private FolderBrowserDialog folderBrowserDialog1;
  }
}

