using System;
using System.Windows.Forms;

namespace MangaEdenNETDownloaderAPI
{
  public partial class frmWaitDialog : Form
  {
    public Action Worker { get; set; }
    public frmWaitDialog()
    {
      InitializeComponent();
      
    }

    protected override void OnLoad(EventArgs e)
    {
      //base.OnLoad(e);
      //Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void Form2_Load(object sender, EventArgs e)
    {
     // this.Location = this.Owner.Location;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form1 form1 = Application.OpenForms["Form1"] as Form1;
      form1.bgwCreazioneListaDownload.CancelAsync();

    }

    private void lblCreaListaDownload_Click(object sender, EventArgs e)
    {

    }
  }
}
