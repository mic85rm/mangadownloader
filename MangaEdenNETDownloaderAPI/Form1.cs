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
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.IO.Compression;
using NLog;
using System.Web;
using System.Xml;
using System.Data.SqlClient;
using System.Xml.Serialization;



//namespace WindowsFormsApp2
namespace MangaEdenNETDownloaderAPI
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
    private const string K_NomeInizialeCapitolo = "CH";

    #endregion

    #region dichiarazione variabili
    ListaManga listamanga = new ListaManga();
    PaginaCapitoli paginacapitoli = new PaginaCapitoli();
    List<CAPITOLI> listacapitoli = new List<CAPITOLI>();
    DataTable data = new DataTable();
    DataTable dtlistamanga = new DataTable();
    List<string> listaimmagini = new List<string>();
    List<int> numeropaginepercapitolo = new List<int>();
    frmWaitDialog frm = new frmWaitDialog();
    //frmWaitDialog frm = Application.OpenForms["Form2"] as frmWaitDialog;
   // TimeSpan ts = new TimeSpan();
    Stopwatch stopWatch = new Stopwatch();
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    string elapsedTime = "";
    int numeroCapitoliSelezionati = 0;
    Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
    string percorsoSalvataggio = "";
    string descrizione = "";
    string listaNumeriCapitoliLogger = "";
    string nomeManga = "";
    List<string> velocita = new List<string>();
    int numerofilescaricati;
    DateTime m_operationStart;
    DateTime m_creazioneListaStart;
    int contai; 
    #endregion
    public Form1()
    {
      InitializeComponent();

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

      LogManager.Configuration.Variables["mydir"] = ReadSetting("indirizzoSalvataggio");


    }

    private void Form1_Load(object sender, EventArgs e)
    {
     



      // this.ShowInTaskbar = false;
      Logger.Info("Applicazione Inizializzata");
      CaricaListaTitoliManga(K_IndirizzoWebListaMangaEdenItaliana);
      lstboxManga.DataSource = velocita;
      lblNumeroElencoMangaTrovati.Text = "Manga Trovati= " + velocita.Count();
      InizializzaComboBox();
      InizializzaControlli();
      txtCerca.Select();
      //InsertDataToDb(listamanga);

      //CaricaDati();
   
    }


    #region utility



    private void InizializzaControlli()
    {
      string path = ReadSetting("indirizzosalvataggio");
      if (path == string.Empty) { //path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
        path = "c:\\manga\\";
      }
      folderBrowserDialog1.SelectedPath = path;
      txtIndirizzoCartellaSalvataggio.Text = path;
      txtIndirizzoCartellaSalvataggio.Enabled = false;
      tabControl1.TabPages[0].Text = "MangaEden";
      tabControl1.TabPages[1].Text = "Download";
      tabControl1.TabPages[2].Text = "Informazioni";
      lblFileScaricati.Text = "";
      lblTempoStimatoDownload.Text = "";
      lblPerc.Text = "";
      lblCopyright.Text = "Copyright e marchi dei manga, e altri materiali" +
        " promozionali sono ritenuti dai loro rispettivi proprietari e il " +
        "loro utilizzo è permesso solo sotto alcune eque clausole della legge sul" +
        " Copyright. ";

      lblJson.Text = "https://www.newtonsoft.com/json";
      lblNlog.Text = "https://nlog-project.org/";
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

    private static Boolean DownloadRemoteImageFile(string uri, string fileName)
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
        return true;
      }

      catch (Exception ex)
      {
        Logger.Error(fileName + ex.Message);
        return false;
        //MessageBox.Show(ex.Message);

      }
    }




    public string PulisciStringa(string StringaPassata, int opzione = 0)
    {
      if (opzione == 0)
      {
        return StringaPassata.Replace("\n", "").Replace("\r", "").Replace(@"""", "").Replace("[", "").Replace("]", "")
          .Replace("\br", "").Replace("&", "").Replace("&*quot*", "").Replace("&*QUOT*", "").Replace("#039", "").Replace("!<BR />", "")
          .Replace("<BR/>", "");
      }
      if (opzione == 1)
      {
        string[] finale = StringaPassata.Split('.');
        return finale[0];
      }
      else
      {
        StringaPassata = StringaPassata.Replace(',', ' ');
        return StringaPassata;
      }
    }

    public List<string> ConvertToList(IList<JToken> list, string numerocapitolo)
    {
      listaimmagini.Add(K_NomeInizialeCapitolo + AggiungiZeroAlNomeFile(numerocapitolo, numeroCapitoliSelezionati));
      foreach (var array in list)
      {
        string appoggio = EstrazioneIndirizzoImmagine(PulisciStringa(array.ToString()));
        listaimmagini.Add(appoggio);
      }
      listaimmagini.Add(K_NomeInizialeCapitolo + AggiungiZeroAlNomeFile(numerocapitolo, numeroCapitoliSelezionati));

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
    public static string AggiungiZeroAlNomeFile(int numeroCapitolo, int cifreNumeroFoto)
    {//per i file immagine
      int i = 0;
      int numeroAppoggio = cifreNumeroFoto;
      while ((numeroAppoggio != 0))
      {
        numeroAppoggio /= 10;
        i++;
      }

      string numeroDaStampare = numeroCapitolo.ToString().PadLeft(i + 1, '0');
      //ad ogni iterazione del ciclo : numeroDaStampare = 030 ; 029 ; 028 ... 009 ; 008 ecc.
      return numeroDaStampare;

    }


    public static string AggiungiZeroAlNomeFile(string numeroCapitolo, int cifreNumeroCapitoli)
    {//per i capitoli
      int i = 0;
      int numeroAppoggio = cifreNumeroCapitoli;
      while ((numeroAppoggio != 0))
      {
        numeroAppoggio /= 10;
        i++;
      }
      string numeroDaStampare = numeroCapitolo.PadLeft(i + 1, '0');

      return numeroDaStampare;

    }




    public DataTable ConvertListToDataTable(IList<JToken> list)
    {
      list = list.Reverse().ToList();
      // New table.
      DataTable table = new DataTable();
      // Add columns.
      for (int i = 0; i < 6; i++)
      {
        table.Columns.Add();
      }
      table.Columns[0].ColumnName = "NumeroCapitolo";
      table.Columns[1].ColumnName = "DataInserimentoUltimoCapitolo";
      table.Columns[2].ColumnName = "TitoloCapitolo";
      table.Columns[3].ColumnName = "IdCapitolo";
      table.Columns[4].ColumnName = "NumeroeTitoloCapitolo";
      table.Columns[5].ColumnName = "NumeroPagineapitolo";
      table.AcceptChanges();
      // Add rows.

      foreach (var array in list)
      {

        array[2] = PulisciStringa(array[2].ToString(), 2);

        string stringaripulita = PulisciStringa(array.ToString()) + ",null";
        string[] stringa_a_vettore = stringaripulita.Split(',');

        for (int i = 0; i < stringa_a_vettore.Count(); i++)
        {
          stringa_a_vettore[i] = stringa_a_vettore[i].TrimStart(' ');
        }

        stringaripulita = stringa_a_vettore.ToString();

        table.Rows.Add(stringa_a_vettore);
      }

      int contarighe = table.Rows.Count;
      if (contarighe > 0)
      {
        string pulizia = PulisciStringa(table.Rows[contarighe - 1]["NumeroCapitolo"].ToString(), 1);
        numeroCapitoliSelezionati = (Convert.ToInt32(pulizia));
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
      if (cbxListaManga.Text.Length >= 3)
      {
        // tremendamente lenta
        string filter_param = cbxListaManga.Text;
        // List<Manga> filteredItems = listamanga.manga.FindAll(x => x.t.ToLower().StartsWith(filter_param.ToLower()));
        //  List<Manga> filteredItems = listamanga.manga.FindAll(x => x.t.ToLower().Contains(filter_param.ToLower()));
        List<string> filteredItems = velocita.FindAll(x => x.ToLower().Contains(filter_param.ToLower()));
        // List<Manga> filteredItems = listamanga.manga.Where(x => x.t.ToLower().Contains(filter_param.ToLower())).ToList();
        cbxListaManga.DataBindings.Clear();
        // cbxListaManga.DisplayMember = "t";
        cbxListaManga.DataSource = filteredItems;

        //cbxListaManga.DataSource= listamanga.manga.Where(x => x.t.ToLower().Contains(filter_param.ToLower())).ToList();

        if (String.IsNullOrWhiteSpace(filter_param))
        {
          cbxListaManga.DataSource = null;
          cbxListaManga.SuspendLayout();
          //cbxListaManga.DisplayMember = "t";
          //cbxListaManga.DataSource = listamanga.manga;
          cbxListaManga.DataSource = velocita;
          cbxListaManga.ResumeLayout(false);

        }
        cbxListaManga.DroppedDown = true;
        Cursor.Current = Cursors.Default;

        cbxListaManga.IntegralHeight = true;



        cbxListaManga.Text = filter_param;


        cbxListaManga.SelectionStart = filter_param.Length;
        cbxListaManga.SelectionLength = 0;
      }
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
      m_creazioneListaStart = DateTime.Now;
      txtCerca.Enabled = false;
      nomeManga = lstboxManga.Text.Replace(" ", "").Replace(@"/", "").Replace(":", "");
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
      if ((chklstbxListaCapitoli.CheckedItems.Count > 0) && (chklstbxListaCapitoli.DataSource != null)) btnConfermaDownload.Enabled = true;
      else btnConfermaDownload.Enabled = false;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      //pictureBox1.ImageLocation =null;
      //int index = listamanga.manga.FindIndex(x=>x.t.Equals(cbxListaManga.Text));
      //if (index != -1)
      //{
      //  pictureBox1.ImageLocation = K_IndirizzoWebCopertineManga + listamanga.manga.ElementAt(index).im;
      //  CaricaListaCapitoli(K_IndirizzoWebListaCapitoliMangaEdenItaliana, listamanga.manga.ElementAt(index).i);

      //  listaimmagini.Clear();
      //  // DataTable table = ConvertListToDataTable(paginacapitoli.chapters);
      //  Popola_chklstbxListaCapitoli(data);

      //  txtTrama.Text = HttpUtility.HtmlDecode(descrizione);
      //}
      //if (chklstbxListaCapitoli.Items.Count==0)
      //{
      //  btnSelectAll.Enabled = false;
      //  btnDeselectAll.Enabled = false;
      //}
      //else
      //{
      //  btnSelectAll.Enabled = true;
      //  btnDeselectAll.Enabled = true;
      //}
    }



    public void InizializzaComboBox()
    {
      //  cbxListaManga.SuspendLayout();
      // cbxListaManga.DisplayMember = "t";
      // cbxListaManga.DataSource= listamanga.manga;
      //  cbxListaManga.ResumeLayout(false);
      //cbxListaManga.DataSource = velocita;

    }
    #endregion

    #region metodi json

    public void CreazioneCodaDownload(string IndirizzoSito, string id, string numerocapitolo)
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

        listaimmagini = ConvertToList(risultati, numerocapitolo);
        // numeropaginepercapitolo.Add(listaimmagini.Count());
        int indice = 0;
        int conta = 0;


        foreach (DataRow row in data.Rows)
        {
          string prova = row[3].ToString();
          if (prova.Equals(id))
          {
            indice = conta;
          }
          conta++;
        }
        data.Rows[indice][5] = risultati.Count().ToString();

      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message, "[CreazioneCodaDownload]");
      }

    }

    public void CaricaListaTitoliManga(string IndirizzoSito)
    {// inserire try catch
      try
      {
        string jsonurl = Uri.EscapeUriString(IndirizzoSito);
        string json = "";
        using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
        {
          json = client.DownloadString(jsonurl);
        }
        // serialize JSON to a string and then write string to a file
        //File.WriteAllText(@"D:\manga\movie.json", JsonConvert.SerializeObject(json));
        
        //// serialize JSON directly to a file
        //using (StreamWriter file = File.CreateText(@"D:\manga\movie2.json"))
        //{
        //  JsonSerializer serializer = new JsonSerializer();
        //  serializer.Serialize(file, json);
        //}

        
        listamanga = JsonConvert.DeserializeObject<ListaManga>(json);
        SerializeObject<ListaManga>(listamanga, @"D:\manga\movie2.xml");
        WriteToJsonFile<ListaManga>( @"D:\manga\mangaedenita.json", listamanga);

        listamanga.manga = listamanga.manga.OrderBy(x => x.t).ToList();
        dtlistamanga = ConvertListToDataTable(listamanga);
        velocita = ConvertiListSoloTitoliManga(listamanga);
      }
      catch (Exception ex)
      {
        Logger.Error(ex.Message, "[CaricaListaTitoliManga]");
      }
    }

    public List<string> ConvertiListSoloTitoliManga(ListaManga listapassata)
    {
      List<string> nuovalista = new List<string>();
      foreach (var item in listapassata.manga)
      {
        nuovalista.Add(item.t);
      }
      return nuovalista;
    }

    public void CaricaListaCapitoli(string IndirizzoSito, string id)
    {
      try
      {
        paginacapitoli = new PaginaCapitoli();
        string jsonurl = Uri.EscapeUriString(IndirizzoSito + id);
        string json = "";
        using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
        {
          json = client.DownloadString(jsonurl);
        }


        JObject cerca = JObject.Parse(json);
        IList<JToken> risultati = cerca["chapters"].Children().ToList();

        data = ConvertListToDataTable(risultati);
        descrizione = cerca["description"].ToString();
      }
      catch (Exception ex)
      {
        Logger.Error(ex, "[CaricaListaCapitoli]");
        // MessageBox.Show(ex.ToString());
      }
    }




    #endregion

    private void btnStartDownload_Click(object sender, EventArgs e)
    {
      m_operationStart = DateTime.Now;
      btnModifica.Enabled = false;
      btnStopDownload.Enabled = true;
      btnApriCartellaSalvataggio.Enabled = false;
      //altra funzione per pulire il titolo

      percorsoSalvataggio = ReadSetting("indirizzosalvataggio") + "\\" + nomeManga;
      this.bgwDownloadAsincrono.RunWorkerAsync();
      // Disable the button for the duration of the download.
      this.btnStart.Enabled = false;
      progressBar.Maximum = 100;

    

      while (this.bgwDownloadAsincrono.IsBusy)
      {
        if (elapsedTime != "")
        {
          //double tempo = (Convert.ToInt32(Math.Truncate(Convert.ToDouble(elapsedTime)) * (listaimmagini.Count)) / 60);
          //lblTempoStimatoDownload.Text = tempo.ToString();
        }
        //progressBar.Increment(1);
        // Keep UI messages moving, so the form remains 
        // responsive during the asynchronous operation.
        Application.DoEvents();

      }



    }

    private void bgwDownloadAsincrono_DoWork(object sender, DoWorkEventArgs e)
    {
      numerofilescaricati = 0;

      var backgroundWorker = sender as BackgroundWorker;
      int numero = 0;
      int primaentrata = 0;
      string percorsoSalvataggioCapitolo = "";
     
      int i = 0;
      listaimmagini.Reverse();
      foreach (string item in listaimmagini)
      {
        int percentage = (i + 1) * 100 / listaimmagini.Count();
        
        backgroundWorker.ReportProgress(percentage);
        i++;
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
         // stopWatch.Start();
          if(DownloadRemoteImageFile(K_IndirizzoWebImmaginiManga + item, percorsoSalvataggioCapitolo + AggiungiZeroAlNomeFile(numero, listaimmagini.Count) + K_EstensioneFileJpg))
            numerofilescaricati++;
          numero++;
          
        //  stopWatch.Stop();
          if (primaentrata == 0)
          {
          //  ts = stopWatch.Elapsed;
          //  elapsedTime = ts.TotalSeconds.ToString();
            primaentrata = 1;
          }
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
      var backgroundWorker = sender as BackgroundWorker;
      listaNumeriCapitoliLogger = string.Empty;
      CheckedListBox.CheckedIndexCollection indices = chklstbxListaCapitoli.CheckedIndices;
      int ii = indices.Count - 1;
      int[] numero = new int[indices.Count];

      contai = 0;
     
      foreach (int index in indices)
      {

        numero[ii] = index;
        ii--;
      }
      Array.Sort(numero);
      //int percentage = 1;
      foreach (int index in numero.Reverse())
      {
        int percentage = (contai + 1) * 100 / numero.Count();
        listaNumeriCapitoliLogger += (data.Rows[index][0].ToString()) + "-";
        //stopWatch.Start();
        backgroundWorker.ReportProgress(percentage);
        contai++;
        CreazioneCodaDownload(K_IndirizzoWebRecuperoImmaginiListaCapitoliMangaEdenItaliana, data.Rows[index][3].ToString(), data.Rows[index][0].ToString());
        if (bgwCreazioneListaDownload.CancellationPending)
        {
          e.Cancel = true;
          return;
        }
        //stopWatch.Stop();
        // ts = stopWatch.Elapsed;
        //elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //         ts.Hours, ts.Minutes, ts.Seconds,
        //         ts.Milliseconds / 10);



      }



      Logger.Info("Titolo=" + nomeManga + ",#capitoli=" + chklstbxListaCapitoli.CheckedItems.Count + ",indicicap=" + listaNumeriCapitoliLogger.TrimEnd('-'));
    }

    private void btoCancel_Click(object sender, EventArgs e)
    {   
      this.bgwDownloadAsincrono.CancelAsync();
      btnStopDownload.Enabled = false;
    }



    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if ((e.ProgressPercentage != 0)&&(numerofilescaricati>0))
      {
        double percentageComplete = (double)e.ProgressPercentage / listaimmagini.Count;
        progressBar.Value = e.ProgressPercentage;
        lblPerc.Text = e.ProgressPercentage.ToString() + "%";
        lblFileScaricati.Text = "File scaricati: " + numerofilescaricati + " di " + ((listaimmagini.Count) - (chklstbxListaCapitoli.CheckedItems.Count * 2));
        double passedMs = (DateTime.Now - m_operationStart).TotalMilliseconds;
        double oneUnitMs = passedMs / numerofilescaricati;
        double leftMs = (listaimmagini.Count() - numerofilescaricati) * oneUnitMs;
        lblTempoStimatoDownload.Text ="Tempo Rimanente Stimato="+TimeSpan.FromMilliseconds(leftMs).ToString(@"hh\:mm\:ss");
      }
    }

    private void bgwCreazioneListaDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      CheckedListBox.CheckedIndexCollection indices = chklstbxListaCapitoli.CheckedIndices;
      if (e.ProgressPercentage != 0)
      {
        frm.progressBar1.Value = e.ProgressPercentage;
        double passedMs = (DateTime.Now - m_creazioneListaStart).TotalMilliseconds;
        double oneUnitMs = passedMs / contai;
        double leftMs = (indices.Count - contai) * oneUnitMs;
        frm.lblCreaListaDownload.Text = "Tempo Rimanente Stimato=" + TimeSpan.FromMilliseconds(leftMs).ToString(@"hh\:mm\:ss");

       
      }
    }

    private void bgwDownloadAsincrono_RunWorkerCompleted(
       object sender,
       RunWorkerCompletedEventArgs e)
    {
      // Set progress bar to 100% in case it's not already there.
      progressBar.Value = 100;
      lblPerc.Text = "100%";
      if (e.Cancelled == true)
      {
        Logger.Info("Download annullato dall'utente ");
        lblPerc.Text = "Download annullato dall'utente ";
        this.btnStart.Enabled = true;
        this.btnStopDownload.Enabled = false;
        btnModifica.Enabled = true;
        btnCerca.Enabled = false;
        btnApriCartellaSalvataggio.Enabled = true;
      }
      else if (e.Error != null)
      {
        Logger.Error(e.Error.ToString(), "CreazioneListaDownload abortita da errore ");
        lblPerc.Text = "Error: " + e.Error.Message;
      }
      else
      {
        MessageBox.Show("DOWNLOAD TERMINATO CON SUCCESSO", "MangaEdenNETDownloaderApi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        Logger.Info("DOWNLOAD TERMINATO CON SUCCESSO ");
        Process.Start(txtIndirizzoCartellaSalvataggio.Text);
        chklstbxListaCapitoli.Enabled = true;
        txtCerca.Enabled = true;
        btnCerca.Enabled = true;
        //cbxListaManga.Enabled = true;
        lstboxManga.Enabled = true;
        lblPerc.Text = "";
        btnSelectAll.Enabled = true;
        btnDeselectAll.Enabled = true;
        this.btnStart.Enabled = false;
        this.btnStopDownload.Enabled = false;
        btnModifica.Enabled = false;
        btnConfermaDownload.Enabled = true;
        btnApriCartellaSalvataggio.Enabled = true;
      }
      // Enable the download button and reset the progress bar.


      progressBar.Value = 0;
      //labelPerc.Text = "0%";
    }


    private void bgwCreazioneListaDownload_RunWorkerCompleted(
       object sender,
       RunWorkerCompletedEventArgs e)
    {
      if (e.Cancelled == true)
      {
        Logger.Info("CreazioneListaDownload abortita dall'utente ");
        listaimmagini.Clear();
        frm.Close();
      }
      else if (e.Error != null)
      {
        Logger.Error(e.Error.ToString(), "CreazioneListaDownload abortita da errore ");
        listaimmagini.Clear();
        frm.Close();
      }
      else
      {
        frm.Close();
        //listaimmagini.Clear();
        tabControl1.SelectTab(1);
        //cbxListaManga.Enabled = false;
        lstboxManga.Enabled = false;
        btnConfermaDownload.Enabled = false;
        chklstbxListaCapitoli.Enabled = false;
        btnSelectAll.Enabled = false;
        btnDeselectAll.Enabled = false;
        btnStart.Enabled = true;
        btnModifica.Enabled = true;
        dataGridView1.DataSource = RigheVisibiliDataGridView(chklstbxListaCapitoli.CheckedIndices);
        ImpostazioniDtgw();
      }


    }

    public DataTable ConvertListToDataTable(ListaManga list)
    {
      DataTable table = new DataTable();

      table.Columns.Add();

      table.Columns[0].ColumnName = "TitoloManga";

      table.AcceptChanges();


      foreach (var item in list.manga)
      {


        table.Rows.Add(item.t);
      }



      return table;
    }








    public DataTable RigheVisibiliDataGridView(CheckedListBox.CheckedIndexCollection indices)
    {
      int k = 0;
      int ii = 0;
      int[] interi_a_vettore = new int[indices.Count];
      DataTable table = new DataTable();
      // 7
      for (int i = 0; i < 6; i++)
      {
        table.Columns.Add();
      }


      table.Columns[4].ColumnName = "NumeroTitoloCapitolo";
      table.Columns[5].ColumnName = "PagineCapitolo";
      // table.Columns[6].ColumnName = "StatoDownload";
      table.AcceptChanges();
      foreach (int index in indices)
      {
        interi_a_vettore[k] = index;
        k++;
      }

      // int vettore[] = lista.Split(',');
      foreach (DataRow dr in data.Rows)
      {
        for (int j = 0; j < interi_a_vettore.Count(); j++)
        {
          if (ii == (interi_a_vettore[j]))
          {

            table.Rows.Add(dr.ItemArray);

          }
        }
        ii++;
      }
      foreach (DataRow row in table.Rows)
      {
        row["NumeroTitoloCapitolo"] = lstboxManga.Text + "  " + row["NumeroTitoloCapitolo"].ToString();
      }
      return table;
    }

    void ImpostazioniDtgw()
    {
      dataGridView1.Columns[0].Visible = false;
      dataGridView1.Columns[1].Visible = false;
      dataGridView1.Columns[2].Visible = false;
      dataGridView1.Columns[3].Visible = false;

      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



    }

    private void btnModifica_Click(object sender, EventArgs e)
    {
      tabControl1.SelectTab(0);
      chklstbxListaCapitoli.Enabled = true;
      txtCerca.Enabled = true;
      btnCerca.Enabled = true;
      //cbxListaManga.Enabled = true;
      lstboxManga.Enabled = true;
      btnSelectAll.Enabled = true;
      btnDeselectAll.Enabled = true;
    }


    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnConfermaDownload.Enabled = false;
      int index = listamanga.manga.FindIndex(x => x.t.Equals(lstboxManga.SelectedItem));
      if (index != -1)
      {
        //CaricaListaCapitoliDatabase(listamanga.manga.ElementAt(index).i);
        CaricaListaCapitoli(K_IndirizzoWebListaCapitoliMangaEdenItaliana, listamanga.manga.ElementAt(index).i);
        pictureBox1.ImageLocation = K_IndirizzoWebCopertineManga + listamanga.manga.ElementAt(index).im;
        Popola_chklstbxListaCapitoli(data);
        txtTrama.Text = HttpUtility.HtmlDecode(descrizione);
      }
      if (chklstbxListaCapitoli.Items.Count == 0)
      {
        btnSelectAll.Enabled = false;
        btnDeselectAll.Enabled = false;
      }
      else
      {
        btnSelectAll.Enabled = true;
        btnDeselectAll.Enabled = true;
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (txtCerca.TextLength >= 1) btnCerca.Enabled = true;
      else
      {
        btnCerca.Enabled = false;
        lstboxManga.DataSource = velocita;
      }
    }

    private void btnCerca_Click(object sender, EventArgs e)
    {
      string filter_param = txtCerca.Text;
      // List<Manga> filteredItems = listamanga.manga.FindAll(x => x.t.ToLower().StartsWith(filter_param.ToLower()));
      //  List<Manga> filteredItems = listamanga.manga.FindAll(x => x.t.ToLower().Contains(filter_param.ToLower()));
      List<string> filteredItems = velocita.FindAll(x => x.ToLower().Contains(filter_param.ToLower()));
      //List<string> filteredItems = velocita.FindAll(x => x.ToLower().StartsWith(filter_param.ToLower()));
      // List<Manga> filteredItems = listamanga.manga.Where(x => x.t.ToLower().Contains(filter_param.ToLower())).ToList();
      //cbxListaManga.DataBindings.Clear();
      // cbxListaManga.DisplayMember = "t";
      if (filteredItems.Count == 0)
      {


        filteredItems.Add("Nessun Risultato Trovato");

      }
      lstboxManga.DataSource = filteredItems;
      //cbxListaManga.DataSource= listamanga.manga.Where(x => x.t.ToLower().Contains(filter_param.ToLower())).ToList();

      if (String.IsNullOrWhiteSpace(filter_param))
      {
        lstboxManga.DataSource = null;
        lstboxManga.SuspendLayout();
        //cbxListaManga.DisplayMember = "t";
        //cbxListaManga.DataSource = listamanga.manga;
        lstboxManga.DataSource = velocita;
        lstboxManga.ResumeLayout(false);

      }
      // cbxListaManga.DroppedDown = true;
      //Cursor.Current = Cursors.Default;

      //cbxListaManga.IntegralHeight = true;



      txtCerca.Text = filter_param;


      //cbxListaManga.SelectionStart = filter_param.Length;
      //cbxListaManga.SelectionLength = 0;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (bgwDownloadAsincrono.IsBusy)
      {
        DialogResult dialogResult = MessageBox.Show("Download in corso sei sicuro di voler uscire?", "MangaEdenNETDownloaderApi", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          bgwDownloadAsincrono.CancelAsync();
        }


      }
    }

    private void lblJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
     
        // Specify that the link was visited.
       // this.lblJson.LinkVisited = true;

        // Navigate to a URL.
        System.Diagnostics.Process.Start("https://www.newtonsoft.com/json");

 
    }

    private void lblNlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      // Specify that the link was visited.
      //this.lblNlog.LinkVisited = true;

      // Navigate to a URL.
      System.Diagnostics.Process.Start("https://nlog-project.org/");

      
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {

    }

    private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      ToolStripItem item = e.ClickedItem;
      switch (item.Name)
      {
        case "tsmiApri":
          this.WindowState = FormWindowState.Normal;
          this.BringToFront();
          break;
        case "chiudiToolStripMenuItem":
             Close();
          break;
      
      }
    }

    public void InsertDataToDb(ListaManga lista)
    {
      string connectionString = ConfigurationManager.ConnectionStrings["connection"].
          ConnectionString;
      
      try
      {
              
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        conn.Open();
        SqlTransaction trans = conn.BeginTransaction();
          //(string sql = "INSERT INTO ListaManga (Alias,IdGenere,Hit,Image,Ld,Status,Titolo,IdManga) " +
          //   "VALUES (@Alias, 0, @Hit,@Image,@Ld,@Status,@Titolo,@IdManga)";
          string sql = "sp_InserisciTitoliManga";
        SqlCommand cmd = new SqlCommand(sql, conn, trans);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;
       
        foreach (var item in listamanga.manga)
        {
          cmd.Parameters.AddWithValue("@Alias", item.a);
          cmd.Parameters.AddWithValue("@hit", item.h);
            if (item.im != null)
            {
              cmd.Parameters.AddWithValue("@Image", item.im);
            }
            else
            {
              cmd.Parameters.AddWithValue("@Image", string.Empty);
            }
          cmd.Parameters.AddWithValue("@Ld", item.ld);
          cmd.Parameters.AddWithValue("@Status", item.s);
          cmd.Parameters.AddWithValue("@Titolo", item.t);
          cmd.Parameters.AddWithValue("@IdManga", item.i);
            
         cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            
          }
        trans.Commit();
          conn.Close();

        }
        //foreach (var item in listamanga.manga)
        //{
        //  CaricaListaCapitoliDatabase(item.i);
        //}
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        
      }
    }


    public void SerializeObject<ListaManga>(ListaManga serializableObject, string fileName)
    {
      if (serializableObject == null) { return; }

      try
      {
        XmlDocument xmlDocument = new XmlDocument();
        XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
        using (MemoryStream stream = new MemoryStream())
        {
          serializer.Serialize(stream, serializableObject);
          stream.Position = 0;
          xmlDocument.Load(stream);
          xmlDocument.Save(fileName);
        }
      }
      catch (Exception ex)
      {
        //Log exception here
      }
    }

    public static void WriteToJsonFile<ListaManga>(string filePath,ListaManga objectToWrite, bool append = false) where ListaManga : new()
    {
      TextWriter writer = null;
      try
      {
        var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
        writer = new StreamWriter(filePath, append);
        writer.Write(contentsToWriteToFile);
      }
      finally
      {
        if (writer != null)
          writer.Close();
      }
    }


    private void CaricaDati()
    {

      string connectionString = ConfigurationManager.ConnectionStrings["connection"].
          ConnectionString;
      BindingSource bsource = new BindingSource();
      try
      {

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          //conn.Open();
          //SqlTransaction trans = conn.BeginTransaction();
          //(string sql = "INSERT INTO ListaManga (Alias,IdGenere,Hit,Image,Ld,Status,Titolo,IdManga) " +
          //   "VALUES (@Alias, 0, @Hit,@Image,@Ld,@Status,@Titolo,@IdManga)";
          string sql = "selectforcombo";
                    
         SqlDataAdapter  da = new SqlDataAdapter(sql, conn);
          conn.Open();
          DataSet ds = new DataSet();

          SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
          da.Fill(ds, "ListaTitoliManga");

          bsource.DataSource = ds.Tables["ListaTitoliManga"];
          lstboxManga.DataSource = bsource;
          lstboxManga.DisplayMember = "titolo";
          conn.Close();

        }

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);

      }

    

    }


    public void CaricaListaCapitoliDatabase(string id,string IndirizzoSito= K_IndirizzoWebListaCapitoliMangaEdenItaliana)
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
        IList<JToken> risultati = cerca["chapters"].Children().ToList();

        ConvertListToDatabase(risultati, id);
        descrizione = cerca["description"].ToString();
      }
      catch (Exception ex)
      {
        Logger.Error(ex, "[CaricaListaCapitoli]");
        // MessageBox.Show(ex.ToString());
      }
    }

    public void ConvertListToDatabase(IList<JToken> list, string id)
    {
    
      string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

      try
      {

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          conn.Open();
          SqlTransaction trans = conn.BeginTransaction();
          string sql = "sp_InserisciCapitoliManga";
          SqlCommand cmd = new SqlCommand(sql, conn, trans);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Connection = conn;

          foreach (var array in list)
          {

            array[2] = PulisciStringa(array[2].ToString(), 2);

            string stringaripulita = PulisciStringa(array.ToString());
            string[] stringa_a_vettore = stringaripulita.Split(',');

            for (int i = 0; i < stringa_a_vettore.Count(); i++)
            {
              stringa_a_vettore[i] = stringa_a_vettore[i].TrimStart(' ');
            }
                                   
            cmd.Parameters.AddWithValue("@NumeroCapitolo", stringa_a_vettore[0]);
            cmd.Parameters.AddWithValue("@TitoloCapitolo", stringa_a_vettore[2]);                       
            cmd.Parameters.AddWithValue("@Ld", UnixTimeStampToDateTime(Convert.ToDouble(stringa_a_vettore[1])));
            cmd.Parameters.AddWithValue("@IdCapitolo", stringa_a_vettore[3]);
            cmd.Parameters.AddWithValue("@IdManga", id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
          }
          trans.Commit();
          conn.Close();

        }

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);

      }
    }
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      return dtDateTime;
    }
  }

}




