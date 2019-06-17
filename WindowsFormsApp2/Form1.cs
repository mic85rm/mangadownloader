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

namespace WindowsFormsApp2
{
  public partial class Form1 : Form
  {

    ListaManga listamanga = new ListaManga();
    PaginaCapitoli paginacapitoli = new PaginaCapitoli();
    List<CAPITOLI> listacapitoli = new List<CAPITOLI>();
    IList<JToken> results = new List<JToken>();
    DataTable data = new DataTable();
    List<string> listaimmagini = new List<string>();
    List<int> numeropaginepercapitolo = new List<int>();
    
    Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed


    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      
      CaricaListaManga("https://www.mangaeden.com/api/list/1/");
      InizializzaComboBox();
     }


    #region utility
    private static void DownloadRemoteImageFile(string uri, string fileName)
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

    public List<string> ConvertToList(IList<JToken> list)
    {

      int numerofile = 0;
      // Add rows.
      foreach (var array in list)
      {
        string appoggio = array.ToString().Replace("\n", "").Replace("\r", "").Replace(@"""", "").Replace("[", "").Replace("]", "");
        string[] ciao = appoggio.Split(',');

        for (int i = 0; i < ciao.Count(); i++)
        {
          ciao[i] = ciao[i].TrimStart(' ');
          // listaimmagini.Add();
        }
        appoggio = ciao[1].ToString();
        listaimmagini.Add(appoggio);
        //string indirizzoSalvataggio = percorsoSalvataggio + TrasformaCifre(numerofile, 6) + ".jpg";
        string indirizzoSalvataggio = "d:\\manga\\" + TrasformaCifre(numerofile, 6) + ".jpg";
        DownloadRemoteImageFile("https://cdn.mangaeden.com/mangasimg/" + appoggio, indirizzoSalvataggio);

        numerofile++;
        //table.Rows.Add(ciao);
      }




      return listaimmagini;
    }
    public static string TrasformaCifre(int num, int cifre)
    {

      string numeroDaStampare = num.ToString().PadLeft(cifre, '0');
      //ad ogni iterazione del ciclo : numeroDaStampare = 030 ; 029 ; 028 ... 009 ; 008 ecc.

      return numeroDaStampare;
    }


    public static DataTable ConvertListToDataTable(IList<JToken> list)
    {
      // New table.
      DataTable table = new DataTable();
      // Add columns.
      for (int i = 0; i < 5; i++)
      {
        table.Columns.Add();
      }

      // Add rows.
      foreach (var array in list)
      {
        string appoggio = array.ToString().Replace("\n", "").Replace("\r", "").Replace(@"""", "").Replace("[", "").Replace("]", "");
        string[] ciao = appoggio.Split(',');

        for (int i = 0; i < ciao.Count(); i++)
        {
          ciao[i] = ciao[i].TrimStart(' ');
        }
        appoggio = ciao.ToString();

        table.Rows.Add(ciao);
      }
      foreach (DataRow row in table.Rows)
      {
        row["Column5"] = row["Column1"].ToString() + " - " + row["Column3"].ToString();
      }



      return table;
    }


    public void popolacls(DataTable dt)
    {

      chklstbxListaCapitoli.DataSource = null;
      DataSet ds = new DataSet();

      ds.Tables.Add(dt);

      BindingSource bs = new BindingSource();
      bs.DataSource = ds;
      bs.DataMember = "Table1";

      chklstbxListaCapitoli.DataSource = bs;
      chklstbxListaCapitoli.DisplayMember = "Column5";

    }

    #endregion

    #region eventi controlli

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

      CheckedListBox.CheckedIndexCollection indices = chklstbxListaCapitoli.CheckedIndices;
      if ((indices.Count) > 1)
      {
        foreach (int index in indices)
        {
          CreazioneCodaDownload("https://www.mangaeden.com/api/chapter/", data.Rows[index][3].ToString());
          //listaimmagini.Add("-");


        }
      }
      else
      {
        CreazioneCodaDownload("https://www.mangaeden.com/api/chapter/", data.Rows[chklstbxListaCapitoli.SelectedIndex][3].ToString());
      }

    }

    private void chklstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (chklstbxListaCapitoli.CheckedItems.Count > 0) btnConfermaDownload.Enabled = true;
      else btnConfermaDownload.Enabled = false;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      pictureBox1.ImageLocation = "https://cdn.mangaeden.com/mangasimg/200x/" + listamanga.manga.ElementAt(cbxListaManga.SelectedIndex).im;
      CaricaListaCapitoli("https://www.mangaeden.com/api/manga/", listamanga.manga.ElementAt(cbxListaManga.SelectedIndex).i);

      // DataTable table = ConvertListToDataTable(paginacapitoli.chapters);
      popolacls(data);
    }

    public void InizializzaComboBox()
    {
      cbxListaManga.DataSource= listamanga.manga;
      cbxListaManga.DisplayMember = "t";
    }
    #endregion

    #region metodi json

    public void CreazioneCodaDownload(string IndirizzoSito, string id)
    {
      paginacapitoli = new PaginaCapitoli();
      string jsonurl = Uri.EscapeUriString(IndirizzoSito + id);
      string json = "";
      using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
      {
        json = client.DownloadString(jsonurl);
      }
      try
      {

        JObject googleSearch = JObject.Parse(json);
        IList<JToken> results = googleSearch["images"].Children().ToList();

        // data = ConvertListToDataTable(results);
        listaimmagini = ConvertToList(results);
        // numeropaginepercapitolo.Add(listaimmagini.Count());
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.ToString());
      }
    }

    public void CaricaListaManga(string IndirizzoSito)
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
        CAPITOLI[] array = new CAPITOLI[5];
   
        JObject googleSearch = JObject.Parse(json);
        IList<JToken> results = googleSearch["chapters"].Children().ToList();
        
        data = ConvertListToDataTable(results);

      }
      catch (Exception ex) {
       
        MessageBox.Show(ex.ToString());
      }
    }

    #endregion


 
   

   


  


   





    






   




  




  }
}
