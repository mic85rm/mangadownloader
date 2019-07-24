namespace WindowsFormsApp1
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(12, 41);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 24;
      this.dataGridView1.Size = new System.Drawing.Size(763, 340);
      this.dataGridView1.TabIndex = 0;
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(12, 387);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(763, 35);
      this.progressBar1.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(667, 440);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(107, 27);
      this.button1.TabIndex = 2;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(21, 440);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 479);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.dataGridView1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
  }
}

