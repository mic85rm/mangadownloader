using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using log4net;
using System.Configuration;
using System.IO.Compression;

namespace WindowsFormsApp2
{
 
  public partial class Form1 : Form
  {

    #region stringhe web
    private const string K_IndirizzoWebListaMangaEdenItaliana = "https://www.mangaeden.com/api/list/1/";
    private const string K_IndirizzoWebRecuperoImmaginiListaCapitoliMangaEdenItaliana = "https://www.mangaeden.com/api/chapter/";
    private const string K_IndirizzoWebImmaginiManga = "https://cdn.mangaeden.com/mangasimg/";
    private const string K_IndirizzoWebCopertineManga = "https://cdn.mangaeden.com/mangasimg/200x/";
    private const string K_IndirizzoWebListaCapitoliMangaEdenItaliana = "https://www.mangaeden.com/api/manga/";
    private const string K_EstensioneFileJpg = ".jpg";
    private const string K_EstensioneFileCbz = ".cbz";
    private const string K_EstensioneFileZip = ".zip";
    private const string K_NomeInizialeCapitolo = "CH0000";
    
    #endregion
    ListaManga listamanga = new ListaManga();
    PaginaCapitoli paginacapitoli = new PaginaCapitoli();
    List<CAPITOLI> listacapitoli = new List<CAPITOLI>();
    DataTable data = new DataTable();
    DataTable dtlistamanga = new DataTable();
    List<string> listaimmagini = new List<string>();
    List<int> numeropaginepercapitolo = new List<int>();
    frmWaitDialog frm = new frmWaitDialog();

    


    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
    string percorsoSalvataggio = "";
    string descrizione = "";
    public Form1()
    {
      InitializeComponent();
      //GlobalContext.Properties["Log"] = ReadSetting("indirizzosalvataggio");  //log file path
     
      bgwDownloadAsincrono = new System.ComponentModel.BackgroundWorker();
      bgwDownloadAsincrono.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownloadAsincrono_DoWork);
      bgwDownloadAsincrono.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownloadAsincrono_RunWorkerCompleted);
      bgwDownloadAsincrono.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
      bgwDownloadAsincrono.WorkerSupportsCancellation = true;
      bgwDownloadAsincrono.WorkerReportsProgress = true;

      bgwCreazioneListaDownload = new System.ComponentModel.BackgroundWorker();
      bgwCreazioneListaDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCreazioneListaDownload_DoWork);
      bgwCreazioneListaDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCreazioneListaDownload_RunWorkerCompleted);
      bgwCreazioneListaDownload.ProgressChanged += new ProgressChangedEventHandler(bgwCreazioneListaDownload_ProgressChanged);
      bgwCreazioneListaDownload.WorkerSupportsCancellation = true;
      bgwCreazioneListaDownload.WorkerReportsProgress = true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      CaricaListaTitoliManga(K_IndirizzoWebListaMangaEdenItaliana);
      InizializzaComboBox();
      InizializzaControlli();
     }


    #region utility



   private void InizializzaControlli()
    {
      string path = ReadSetting("indirizzosalvataggio");
      if (path == string.Empty) { path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
      folderBrowserDialog1.SelectedPath = path;
      txtIndirizzoCartellaSalvataggio.Text = path;
      txtIndirizzoCartellaSalvataggio.Enabled = false;
      tabControl1.TabPages[0].Text = "MangaEden";
      tabControl1.TabPages[1].Text = "Download";
      tabControl1.TabPages[2].Text = "Informazioni";
      GlobalContext.Properties["LogFileName"] = "d:\\manga";
      log4net.Config.XmlConfigurator.Configure();
      //log4net.XmlConfigurator.Configure();
    }

    static string ReadSetting(string key)
    {
      try
      {
        var appSettings = ConfigurationManager.AppSettings;
        string result = appSettings[key] ?? "Not Found";
        return result;
      }
      catch (ConfigurationErrorsException)
      {
        return null;
      }
    }

    static void AddUpdateAppSettings(string key, string value)
    {
      try
      {
        var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var settings = configFile.AppSettings.Settings;
        if (settings[key] == null)
        {
          settings.Add(key, value);
        }
        else
        {
          settings[key].Value = value;
        }
        configFile.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
      }
      catch (ConfigurationErrorsException)
      {
        Console.WriteLine("Error writing app settings");
      }
    }

    private static void DownloadRemoteImageFile(string uri, string fileName)
    {
      try
      {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

        //request.Proxy = WebRequest.DefaultWebProxy;
        //request.Credentials = System.Net.CredentialCache.DefaultCredentials; ;
        //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // Check that the remote file was found. The ContentType
        // check is performed since a request for a non-existent
        // image file might be redirected to a 404-page, which would
        // yield the StatusCode "OK", even though the image was not
        // found.
        if ((response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.Moved ||
            response.StatusCode == HttpStatusCode.Redirect) &&
            response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
        {

          // if the remote file was found, download oit
          using (Stream inputStream = response.GetResponseStream())
          using (Stream outputStream = File.OpenWrite(fileName))
          {
            byte[] buffer = new byte[4096];
            int bytesRead;
            do
            {
              bytesRead = inputStream.Read(buffer, 0, buffer.Length);
              outputStream.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
          }
        }
      }
      catch (Exception ex) {
        log.Fatal(ex.Message);
      }
    }


  

    public string PulisciStringa(string StringaPassata)
    {
      // return StringaPassata.Replace("\n", "").Replace("\r", "").Replace(@"""", "").Replace("[", "").Replace("]", "");
      return StringaPassata.Replace("\n", "").Replace("\r", "").Replace(@"""", "").Replace("[", "").Replace("]", "")
        .Replace("\br","").Replace("&", "").Replace("&*quot*", "").Replace("&*QUOT*", "").Replace("#039", "").Replace("!<BR />","")
        .Replace("<BR/>", ""); 
    }

    public List<string> ConvertToList(IList<JToken> list,string numerocapitolo)
    {
      listaimmagini.Add(K_NomeInizialeCapitolo + numerocapitolo);
      foreach (var array in list)
      {
        
        string appoggio = EstrazioneIndirizzoImmagine(PulisciStringa(array.ToString()));
        listaimmagini.Add(appoggio);
      }
      listaimmagini.Add(K_NomeInizialeCapitolo + numerocapitolo);
      listaimmagini.Reverse();
      return listaimmagini;
    }

    public string EstrazioneIndirizzoImmagine(string StringaDaSplittare)
    {
      string[] stringatoarray = StringaDaSplittare.Split(',');

      for (int i = 0; i < stringatoarray.Count(); i++)
      {
        stringatoarray[i] = stringatoarray[i].TrimStart(' ');
       }
      return stringatoarray[1].ToString();
    }
    public static string AggiungiZeroAlNomeFile(int num, int cifre)
    {
      string numeroDaStampare = num.ToString().PadLeft(cifre, '0');
      //ad ogni iterazione del ciclo : numeroDaStampare = 030 ; 029 ; 028 ... 009 ; 008 ecc.
      return numeroDaStampare;
    }


    public  DataTable ConvertListToDataTable(IList<JToken> list)
    {
      list=list.Reverse().ToList();
      // New table.
      DataTable table = new DataTable();
      // Add columns.
      for (int i = 0; i < 5; i++)
      {
        table.Columns.Add();
      }
      table.Columns[0].ColumnName = "NumeroCapitolo";
      table.Columns[1].ColumnName = "DataInserimentoUltimoCapitolo";
      table.Columns[2].ColumnName = "TitoloCapitolo";
      table.Columns[3].ColumnName = "IdCapitolo";
      table.Columns[4].ColumnName = "NumeroeTitoloCapitolo";
      table.AcceptChanges();
      // Add rows.
      foreach (var array in list)
      {
        string stringaripulita = PulisciStringa(array.ToString());
        string[] stringa_a_vettore = stringaripulita.Split(',');

        for (int i = 0; i < stringa_a_vettore.Count(); i++)
             {
          stringa_a_vettore[i] = stringa_a_vettore[i].TrimStart(' ');
        }
        stringaripulita = stringa_a_vettore.ToString();

        table.Rows.Add(stringa_a_vettore);
      }
      foreach (DataRow row in table.Rows)
      {
        row["NumeroeTitoloCapitolo"] = row["NumeroCapitolo"].ToString() + " - " + row["TitoloCapitolo"].ToString();
      }
     return table;
    }


    public void Popola_chklstbxListaCapitoli(DataTable dt)
    {

      chklstbxListaCapitoli.DataSource = null;
      DataSet ds = new DataSet();
      ds.Tables.Add(dt);
      BindingSource bs = new BindingSource();
      bs.DataSource = ds;
      bs.DataMember = "Table1";
      chklstbxListaCapitoli.DataSource = bs;
      chklstbxListaCapitoli.DisplayMember = "NumeroeTitoloCapitolo";
     }

    #endregion

    #region eventi controlli

    private void btnApriCartellaSalvataggio_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.ShowNewFolderButton = false;
      DialogResult result = this.folderBrowserDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        txtIndirizzoCartellaSalvataggio.Text = folderBrowserDialog1.SelectedPath;
        AddUpdateAppSettings("indirizzosalvataggio", folderBrowserDialog1.SelectedPath);
      }
    }

    private void CbxListaManga_TextChanged(object sender, EventArgs e)
    {
    
    
    }
    private void comboBox1_TextUpdate(object sender, EventArgs e)
    {

      // tremendamente lenta
      string filter_param = cbxListaManga.Text;
      // List<Manga> filteredItems = listamanga.manga.FindAll(x => x.t.ToLower().StartsWith(filter_param.ToLower()));
       List<Manga> filteredItems= listamanga.manga.FindAll(x => x.t.ToLower().Contains(filter_param.ToLower()));
    
      // List<Manga> filteredItems = listamanga.manga.Where(x => x.t.ToLower().Contains(filter_param.ToLower())).ToList();
      // another variant for filtering using StartsWith:

      cbxListaManga.DataSource = filteredItems;
    
      //cbxListaManga.DataSource= listamanga.manga.Where(x => x.t.ToLower().Contains(filter_param.ToLower())).ToList();

      if (String.IsNullOrWhiteSpace(filter_param))
      {
        cbxListaManga.DataSource = listamanga.manga;
        cbxListaManga.DisplayMember = "t";
        
      }
      cbxListaManga.DroppedDown = true;
      Cursor.Current = Cursors.Default;
      // this will ensure that the drop down is as long as the list
      cbxListaManga.IntegralHeight = true;

      // remove automatically selected first item
     // cbxListaManga.SelectedIndex = -1;

      cbxListaManga.Text = filter_param;

      // set the position of the cursor
      cbxListaManga.SelectionStart = filter_param.Length;
      cbxListaManga.SelectionLength = 0;
    }



    private void BtnDeselectAll_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < chklstbxListaCapitoli.Items.Count; i++)
      {
        chklstbxListaCapitoli.SetItemChecked(i, false);
      }

      btnConfermaDownload.Enabled = false;
    }

    private void BtnSelectAll_Click(object sender, EventArgs e)
    {
      if (chklstbxListaCapitoli.Items.Count > 0)
      {
        for (int i = 0; i < chklstbxListaCapitoli.Items.Count; i++)
        {
          chklstbxListaCapitoli.SetItemChecked(i, true);
        }

        btnConfermaDownload.Enabled = true;
      }
    }

    private void btnConfermaDownload_Click(object sender, EventArgs e)
    {
      listaimmagini.Clear();
      this.bgwCreazioneListaDownload.RunWorkerAsync();

      // tabControl1.SelectTab(1);
      
       
      frm.Location = new Point(
    (this.Location.X + this.Width / 2) - (frm.Width / 2),
    (this.Location.Y + this.Height / 2) - (frm.Height / 2));
      frm.StartPosition = FormStartPosition.Manual;
      frm.ShowDialog(this);
      while (this.bgwCreazioneListaDownload.IsBusy)
      {
        //progressBar.Increment(1);
        // Keep UI messages moving, so the form remains 
        // responsive during the asynchronous operation.
        Application.DoEvents();

      }
      
    }

    private void chklstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (chklstbxListaCapitoli.CheckedItems.Count > 0) btnConfermaDownload.Enabled = true;
      else btnConfermaDownload.Enabled = false;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = listamanga.manga.FindIndex(x=>x.t.Equals(cbxListaManga.Text));
      if (index != -1)
      {
        pictureBox1.ImageLocation = K_IndirizzoWebCopertineManga + listamanga.manga.ElementAt(index).im;
        CaricaListaCapitoli(K_IndirizzoWebListaCapitoliMangaEdenItaliana, listamanga.manga.ElementAt(index).i);

        listaimmagini.Clear();
        // DataTable table = ConvertListToDataTable(paginacapitoli.chapters);
        Popola_chklstbxListaCapitoli(data);
        textBox1.Text = PulisciStringa(descrizione);
      }
    }
    


    public void InizializzaComboBox()
    {
      cbxListaManga.DataSource= listamanga.manga;
      cbxListaManga.DisplayMember = "t";
    }
    #endregion

    #region metodi json

    public void CreazioneCodaDownload(string IndirizzoSito, string id,string numerocapitolo)
    {
      try
      {
        string jsonurl = Uri.EscapeUriString(IndirizzoSito + id);
      string json = "";
      using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
      {
        json = client.DownloadString(jsonurl);
      }
      
        JObject cerca = JObject.Parse(json);
        IList<JToken> risultati = cerca["images"].Children().ToList();

        // data = ConvertListToDataTable(results);
        listaimmagini = ConvertToList(risultati,numerocapitolo);
        // numeropaginepercapitolo.Add(listaimmagini.Count());
      }
      catch (Exception ex)
      {
        log.Fatal(ex.Message);
        //MessageBox.Show(ex.ToString());
      }
    }

    public void CaricaListaTitoliManga(string IndirizzoSito)
    {
      string jsonurl = Uri.EscapeUriString(IndirizzoSito);
      string json = "";
      using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
      {
        json = client.DownloadString(jsonurl);
      }
      listamanga = JsonConvert.DeserializeObject<ListaManga>(json);
      
      listamanga.manga=listamanga.manga.OrderBy(x=>x.t).ToList();
      dtlistamanga=ConvertListToDataTable(listamanga);
    }


    public void CaricaListaCapitoli(string IndirizzoSito,string id)
    {
      try
      {
        paginacapitoli = new PaginaCapitoli();
      string jsonurl = Uri.EscapeUriString(IndirizzoSito+id);
      string json = "";
      using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
      {
        json = client.DownloadString(jsonurl);
      }
      
     
        JObject cerca = JObject.Parse(json);
        IList<JToken> risultati = cerca["chapters"].Children().ToList();
        
        data = ConvertListToDataTable(risultati);
        descrizione= cerca["description"].ToString();
      }
      catch (Exception ex) {
       
        MessageBox.Show(ex.ToString());
      }
    }




    #endregion

    private void button4_Click(object sender, EventArgs e)
    {
      this.bgwDownloadAsincrono.RunWorkerAsync();
      btnStopDownload.Enabled = true;
      percorsoSalvataggio = ReadSetting("indirizzosalvataggio") + "\\" + cbxListaManga.Text.ToString();
      // Disable the button for the duration of the download.
      this.btnStart.Enabled = false;
      progressBar.Maximum = listaimmagini.Count();
      
      // Once you have started the background thread you 
      // can exit the handler and the application will 
      // wait until the RunWorkerCompleted event is raised.

      // Or if you want to do something else in the main thread,
      // such as update a progress bar, you can do so in a loop 
      // while checking IsBusy to see if the background task is
      // still running.

      while (this.bgwDownloadAsincrono.IsBusy)
      {
        //progressBar.Increment(1);
        // Keep UI messages moving, so the form remains 
        // responsive during the asynchronous operation.
        Application.DoEvents();
       
      }



    }

    private void bgwDownloadAsincrono_DoWork( object sender,DoWorkEventArgs e)
    {
   

      var backgroundWorker = sender as BackgroundWorker;
      int numero = 0;
      string percorsoSalvataggioCapitolo = "";
      int percent;
      //string percorsoSalvataggio = ReadSetting("indirizzosalvataggio") + "\\" + listamanga.manga.ElementAt(cbxListaManga.SelectedIndex).t.ToString();
      foreach (string item in listaimmagini)
      {
        percent = numero;
        backgroundWorker.ReportProgress(percent);
        
        if (item.Contains(K_NomeInizialeCapitolo))
        {
          percorsoSalvataggioCapitolo = percorsoSalvataggio + item + "\\";
          numero = 0;
          if (!Directory.Exists(percorsoSalvataggio + item))
          {

            Directory.CreateDirectory(percorsoSalvataggio + item);
            
          }
          else
          {
          
            if ((File.Exists(percorsoSalvataggio + item + K_EstensioneFileCbz)))
            {
                       
              File.Delete(percorsoSalvataggio + item + K_EstensioneFileCbz);
              ZipFile.CreateFromDirectory(percorsoSalvataggio + item, percorsoSalvataggio + item + K_EstensioneFileCbz, CompressionLevel.Fastest, true);
            }
            else
            {
              ZipFile.CreateFromDirectory(percorsoSalvataggio + item, percorsoSalvataggio + item + K_EstensioneFileCbz, CompressionLevel.Fastest, true);
            }
          }

        }
        else
        {


          DownloadRemoteImageFile(K_IndirizzoWebImmaginiManga + item, percorsoSalvataggioCapitolo + AggiungiZeroAlNomeFile(numero, 6) + K_EstensioneFileJpg);
          numero++;

        }
        if (bgwDownloadAsincrono.CancellationPending)
        {
          e.Cancel = true;
          return;
        }
      }
    }

    private void bgwCreazioneListaDownload_DoWork(object sender, DoWorkEventArgs e)
    {
      CheckedListBox.CheckedIndexCollection indices = chklstbxListaCapitoli.CheckedIndices;
     
        foreach (int index in indices)
        {
          CreazioneCodaDownload(K_IndirizzoWebRecuperoImmaginiListaCapitoliMangaEdenItaliana, data.Rows[index][3].ToString(), data.Rows[index][0].ToString());
        if (bgwCreazioneListaDownload.CancellationPending)
        {
          e.Cancel = true;
          return;
        }
      }
     
    }

    private void btoCancel_Click(object sender, EventArgs e)
    {
      //notify background worker we want to cancel the operation.  
      //this code doesn't actually cancel or kill the thread that is executing the job.  
     this.bgwDownloadAsincrono.CancelAsync();
      btnStopDownload.Enabled = false;
      
    }
   
    
    public void AnnullaCreazioneListaDownload(object sender, EventArgs e)
    {
      //notify background worker we want to cancel the operation.  
      //this code doesn't actually cancel or kill the thread that is executing the job.  
      bgwCreazioneListaDownload.CancelAsync();
      

    }

    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar.Value = e.ProgressPercentage;
      labelPerc.Text = e.ProgressPercentage.ToString() + "%";
    }

    private void bgwCreazioneListaDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
     
        frm.progressBar1.Value = e.ProgressPercentage;
    
      //labelPerc.Text = e.ProgressPercentage.ToString() + "%";
    }

    private void bgwDownloadAsincrono_RunWorkerCompleted(
       object sender,
       RunWorkerCompletedEventArgs e)
    {
      // Set progress bar to 100% in case it's not already there.
      progressBar.Value = listaimmagini.Count();
      if (e.Cancelled == true)
      {
        labelPerc.Text = "Canceled!";
      }
      else if (e.Error != null)
      {
        labelPerc.Text = "Error: " + e.Error.Message;
      }
      else
      {
        MessageBox.Show("DOWNLOAD TERMINATO CON SUCCESSO");
        chklstbxListaCapitoli.Enabled = true;
        cbxListaManga.Enabled = true;
        labelPerc.Text = "Done!";
      }
         // Enable the download button and reset the progress bar.
      this.btnStart.Enabled = true;
      this.btnStopDownload.Enabled = false;
      progressBar.Value = 0;
      //labelPerc.Text = "0%";
    }


    private void bgwCreazioneListaDownload_RunWorkerCompleted(
       object sender,
       RunWorkerCompletedEventArgs e)
    {
      if (e.Cancelled == true)
      {
        listaimmagini.Clear();
        frm.Close();
      }
      else if (e.Error != null)
      {
        
        listaimmagini.Clear();
        frm.Close();
      }
      else
      {
        frm.Close();
        //listaimmagini.Clear();
        tabControl1.SelectTab(1);
        cbxListaManga.Enabled = false;
        btnConfermaDownload.Enabled = false;
        chklstbxListaCapitoli.Enabled = false;
        btnSelectAll.Enabled = false;
        btnDeselectAll.Enabled = false;
        btnStart.Enabled = true;
      }

     
    }

    public DataTable ConvertListToDataTable(ListaManga list)
    {     
       DataTable table = new DataTable();
       
      table.Columns.Add();
      
      table.Columns[0].ColumnName = "TitoloManga";
      
      table.AcceptChanges();
    

      foreach(var item in list.manga)
       {
          

       table.Rows.Add(item.t);
     }
      


      return table;
    }
    private void groupBox6_Enter(object sender, EventArgs e)
    {

    }

    private void button4_Click_1(object sender, EventArgs e)
    {
      MessageBox.Show(cbxListaManga.Text);
    }

    private void groupBox7_Enter(object sender, EventArgs e)
    {

    }


    void CreoListaCodaDownload()
    {
      CheckedListBox.CheckedIndexCollection indices = chklstbxListaCapitoli.CheckedIndices;
      
        foreach (int index in indices)
        {
          CreazioneCodaDownload(K_IndirizzoWebRecuperoImmaginiListaCapitoliMangaEdenItaliana, data.Rows[index][3].ToString(), data.Rows[index][0].ToString());
        }
  
    }
  }
}
