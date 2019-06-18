﻿using Newtonsoft.Json;
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
    #endregion
    ListaManga listamanga = new ListaManga();
    PaginaCapitoli paginacapitoli = new PaginaCapitoli();
    List<CAPITOLI> listacapitoli = new List<CAPITOLI>();
    DataTable data = new DataTable();
    List<string> listaimmagini = new List<string>();
    List<int> numeropaginepercapitolo = new List<int>();
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed


    public Form1()
    {
      InitializeComponent();
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
      return StringaPassata.Replace("\n", "").Replace("\r", "").Replace(@"""", "").Replace("[", "").Replace("]", "");
    }

    public List<string> ConvertToList(IList<JToken> list,string numerocapitolo)
    {
      //string percorsoSalvataggio = "";
      //int numerofile = 0;
      // Add rows.
      List<string> listaimmagini = new List<string>();
      listaimmagini.Add("CH00000"+numerocapitolo);
      foreach (var array in list)
      {
        
        string appoggio = EstrazioneIndirizzoImmagine(PulisciStringa(array.ToString()));
        listaimmagini.Add(appoggio);
      //   string indirizzoSalvataggio = percorsoSalvataggio + AggiungiZeroAlNomeFile(numerofile, 6) + K_EstensioneFileJpg;
       // DownloadRemoteImageFile(K_IndirizzoWebImmaginiManga + appoggio, indirizzoSalvataggio);

        //numerofile++;
      }
      listaimmagini.Add("CH00000" + numerocapitolo);
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

      cbxListaManga.DroppedDown = false;
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
      btnStart.Enabled = true;
      tabControl1.SelectTab(1);
      CheckedListBox.CheckedIndexCollection indices = chklstbxListaCapitoli.CheckedIndices;
      if ((indices.Count) > 1)
      {
        foreach (int index in indices)
        {
         // nomecartella.Add(data.Rows[index][0].ToString());
          CreazioneCodaDownload(K_IndirizzoWebRecuperoImmaginiListaCapitoliMangaEdenItaliana, data.Rows[index][3].ToString(), data.Rows[index][0].ToString());
          //listaimmagini.Add("-");


        }
      }
      else
      {
        CreazioneCodaDownload(K_IndirizzoWebRecuperoImmaginiListaCapitoliMangaEdenItaliana, data.Rows[chklstbxListaCapitoli.SelectedIndex][3].ToString(), data.Rows[chklstbxListaCapitoli.SelectedIndex][0].ToString());
      }

    }

    private void chklstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (chklstbxListaCapitoli.CheckedItems.Count > 0) btnConfermaDownload.Enabled = true;
      else btnConfermaDownload.Enabled = false;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      pictureBox1.ImageLocation = K_IndirizzoWebCopertineManga + listamanga.manga.ElementAt(cbxListaManga.SelectedIndex).im;
      CaricaListaCapitoli(K_IndirizzoWebListaCapitoliMangaEdenItaliana, listamanga.manga.ElementAt(cbxListaManga.SelectedIndex).i);
      List<string> listaimmagini = new List<string>();
      // DataTable table = ConvertListToDataTable(paginacapitoli.chapters);
      Popola_chklstbxListaCapitoli(data);
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
      string jsonurl = Uri.EscapeUriString(IndirizzoSito + id);
      string json = "";
      using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
      {
        json = client.DownloadString(jsonurl);
      }
      try
      {

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
    }


    public void CaricaListaCapitoli(string IndirizzoSito,string id)
    {
      paginacapitoli = new PaginaCapitoli();
      string jsonurl = Uri.EscapeUriString(IndirizzoSito+id);
      string json = "";
      using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
      {
        json = client.DownloadString(jsonurl);
      }
      try
      {
     
        JObject cerca = JObject.Parse(json);
        IList<JToken> risultati = cerca["chapters"].Children().ToList();
        
        data = ConvertListToDataTable(risultati);

      }
      catch (Exception ex) {
       
        MessageBox.Show(ex.ToString());
      }
    }




    #endregion

    private void button4_Click(object sender, EventArgs e)
    {
      int numero = 0;
      string percorsoSalvataggioCapitolo = "";
      string percorsoSalvataggio = ReadSetting("indirizzosalvataggio") + "\\"+listamanga.manga.ElementAt(cbxListaManga.SelectedIndex).t.ToString() ;
      foreach (string item in listaimmagini)
      {
        if (item.Contains("CH00000")) {
          if (!Directory.Exists(percorsoSalvataggio+item))
          {
           
            Directory.CreateDirectory(percorsoSalvataggio+item);
            percorsoSalvataggioCapitolo = percorsoSalvataggio + item+"\\";
             numero = 0;
          }
          else
          {
            ZipFile.CreateFromDirectory(percorsoSalvataggio + item, percorsoSalvataggio + item+".zip");

          }

        }
        else
        {

          DownloadRemoteImageFile(K_IndirizzoWebImmaginiManga + item,percorsoSalvataggioCapitolo+AggiungiZeroAlNomeFile(numero,6) +K_EstensioneFileJpg);
          numero++;
        }

      }
    }
  }
}
