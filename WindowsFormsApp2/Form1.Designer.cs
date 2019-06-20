﻿using System.Windows.Forms;

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
      this.labelPerc = new System.Windows.Forms.Label();
      this.txtIndirizzoCartellaSalvataggio = new System.Windows.Forms.TextBox();
      this.btnApriCartellaSalvataggio = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.groupBox7 = new System.Windows.Forms.GroupBox();
      this.groupBox8 = new System.Windows.Forms.GroupBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.groupBox9 = new System.Windows.Forms.GroupBox();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.groupBox10 = new System.Windows.Forms.GroupBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.groupBox9.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.groupBox10.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.groupBox6);
      this.groupBox1.Controls.Add(this.groupBox5);
      this.groupBox1.Location = new System.Drawing.Point(12, 105);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1003, 684);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Anteprima Manga";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(421, 623);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(173, 25);
      this.button3.TabIndex = 7;
      this.button3.Text = "Deseleziona Tutto";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.BtnDeselectAll_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(275, 623);
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
      this.chklstbxListaCapitoli.Location = new System.Drawing.Point(6, 19);
      this.chklstbxListaCapitoli.Name = "chklstbxListaCapitoli";
      this.chklstbxListaCapitoli.Size = new System.Drawing.Size(606, 599);
      this.chklstbxListaCapitoli.TabIndex = 4;
      this.chklstbxListaCapitoli.SelectedIndexChanged += new System.EventHandler(this.chklstbxListaCapitoli_SelectedIndexChanged);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(16, 21);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(328, 375);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // btnConfermaDownload
      // 
      this.btnConfermaDownload.Enabled = false;
      this.btnConfermaDownload.Location = new System.Drawing.Point(550, 36);
      this.btnConfermaDownload.Name = "btnConfermaDownload";
      this.btnConfermaDownload.Size = new System.Drawing.Size(459, 60);
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
      this.cbxListaManga.Location = new System.Drawing.Point(16, 21);
      this.cbxListaManga.Name = "cbxListaManga";
      this.cbxListaManga.Size = new System.Drawing.Size(455, 24);
      this.cbxListaManga.TabIndex = 3;
      this.cbxListaManga.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
      this.tabControl1.Size = new System.Drawing.Size(1032, 830);
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
      this.tabPage1.Size = new System.Drawing.Size(1024, 801);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
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
      this.tabPage2.Size = new System.Drawing.Size(1024, 801);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // labelPerc
      // 
      this.labelPerc.AutoSize = true;
      this.labelPerc.Location = new System.Drawing.Point(26, 40);
      this.labelPerc.Name = "labelPerc";
      this.labelPerc.Size = new System.Drawing.Size(16, 17);
      this.labelPerc.TabIndex = 0;
      this.labelPerc.Text = "a";
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
      // btnStart
      // 
      this.btnStart.Enabled = false;
      this.btnStart.Location = new System.Drawing.Point(23, 107);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(220, 45);
      this.btnStart.TabIndex = 5;
      this.btnStart.Text = "Inizia Download";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.button4_Click);
      // 
      // button1
      // 
      this.button1.Enabled = false;
      this.button1.Location = new System.Drawing.Point(249, 107);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(197, 45);
      this.button1.TabIndex = 4;
      this.button1.Text = "Annulla";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.btoCancel_Click);
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(23, 60);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(918, 41);
      this.progressBar.TabIndex = 3;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerSupportsCancellation = true;
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
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.labelPerc);
      this.groupBox3.Controls.Add(this.btnStart);
      this.groupBox3.Controls.Add(this.button1);
      this.groupBox3.Controls.Add(this.progressBar);
      this.groupBox3.Location = new System.Drawing.Point(41, 559);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(964, 189);
      this.groupBox3.TabIndex = 9;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Download File";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.cbxListaManga);
      this.groupBox4.Location = new System.Drawing.Point(20, 36);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(496, 60);
      this.groupBox4.TabIndex = 6;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Lista Manga";
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(928, 538);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.groupBox7);
      this.groupBox5.Controls.Add(this.pictureBox1);
      this.groupBox5.Location = new System.Drawing.Point(8, 29);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(365, 649);
      this.groupBox5.TabIndex = 8;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Copertina e Informazioni";
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.chklstbxListaCapitoli);
      this.groupBox6.Controls.Add(this.button2);
      this.groupBox6.Controls.Add(this.button3);
      this.groupBox6.Location = new System.Drawing.Point(379, 23);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(618, 655);
      this.groupBox6.TabIndex = 9;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Capitoli";
      // 
      // groupBox7
      // 
      this.groupBox7.Location = new System.Drawing.Point(16, 402);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new System.Drawing.Size(321, 240);
      this.groupBox7.TabIndex = 1;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "groupBox7";
      // 
      // groupBox8
      // 
      this.groupBox8.Controls.Add(this.checkBox3);
      this.groupBox8.Controls.Add(this.checkBox2);
      this.groupBox8.Controls.Add(this.checkBox1);
      this.groupBox8.Location = new System.Drawing.Point(54, 117);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new System.Drawing.Size(556, 76);
      this.groupBox8.TabIndex = 10;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "groupBox8";
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(262, 33);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(98, 21);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(138, 33);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(98, 21);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "checkBox2";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point(6, 33);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(98, 21);
      this.checkBox3.TabIndex = 2;
      this.checkBox3.Text = "checkBox3";
      this.checkBox3.UseVisualStyleBackColor = true;
      // 
      // groupBox9
      // 
      this.groupBox9.Controls.Add(this.richTextBox1);
      this.groupBox9.Controls.Add(this.numericUpDown1);
      this.groupBox9.Location = new System.Drawing.Point(48, 227);
      this.groupBox9.Name = "groupBox9";
      this.groupBox9.Size = new System.Drawing.Size(572, 76);
      this.groupBox9.TabIndex = 11;
      this.groupBox9.TabStop = false;
      this.groupBox9.Text = "groupBox9";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(19, 32);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(116, 22);
      this.numericUpDown1.TabIndex = 0;
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(239, 24);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(127, 30);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      // 
      // groupBox10
      // 
      this.groupBox10.Controls.Add(this.textBox1);
      this.groupBox10.Location = new System.Drawing.Point(41, 328);
      this.groupBox10.Name = "groupBox10";
      this.groupBox10.Size = new System.Drawing.Size(957, 214);
      this.groupBox10.TabIndex = 12;
      this.groupBox10.TabStop = false;
      this.groupBox10.Text = "groupBox10";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 21);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(917, 175);
      this.textBox1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1056, 853);
      this.Controls.Add(this.tabControl1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "MangaEdenDownloader";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.groupBox9.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.groupBox10.ResumeLayout(false);
      this.groupBox10.PerformLayout();
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
    private Label labelPerc;
    private Button btnStart;
    private Button button1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
    private TextBox textBox1;
    private GroupBox groupBox9;
    private RichTextBox richTextBox1;
    private NumericUpDown numericUpDown1;
    private GroupBox groupBox8;
    private CheckBox checkBox3;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
  }
}

