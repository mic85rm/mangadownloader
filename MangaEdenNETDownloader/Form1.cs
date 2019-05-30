using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MangaEdenNETDownloader
{

  public partial class Form1 : Form
  {
    List<MANGA> Manga = new List<MANGA>();

    public Form1()
    {
      InitializeComponent();

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      InizializzaControlli();

    }






    #region metodi recupero info html
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




    private bool OttieniListaCapitoli(string link)
    {
      var html = link;
      HtmlWeb web = new HtmlWeb();

      var htmlDoc = web.Load(html);
      var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//td/a[@class='chapterLink']");
     
      
      foreach (var node in htmlNodes)
      {
        MANGA oggetto = new MANGA();
        List<string> appoggio = new List<string>();
        oggetto.Attivo = false;
        oggetto.LinkCapitolo = "Https://www.mangaeden.com" + node.Attributes["href"].Value;
        string ricerca = "Capitolo";
        int posizione = node.InnerText.IndexOf(ricerca);
        string stringafinale = node.InnerText;
        stringafinale = stringafinale.Substring(posizione);
        stringafinale=stringafinale.Replace("\n", " ");
        oggetto.NomeCapitolo = stringafinale;
        
       

        
        // oggetto.NumeroPagine=GetNumberPage(oggetto.LinkCapitolo);
        // appoggio=GetListPage(oggetto.LinkCapitolo);

        Manga.Add(oggetto);
      }
      return true;
    }


    private static string GetImageManga(string link)
    {

      string html = link;
      HtmlWeb web = new HtmlWeb();

      var htmlDoc = web.Load(html);
      //string htmlNodes2 = htmlDoc.DocumentNode
      //  .SelectNodes("//div[@class='mangaImage2']/img")
      // .First()
      //      .Attributes["src"].Value;

      string htmlNodes2 = htmlDoc.DocumentNode
        .SelectSingleNode("//div[@class='mangaImage2']/img")

            .Attributes["src"].Value;




      //foreach (var node in htmlNodes)
      //{
      //  if (node.HasClass("chapterLink"))
      return ("https:" + htmlNodes2);
      ///TextBox2.Text= (node.Attributes["href"].Value);

      //}

    }

    private static string GetStatoManga(string link)
    {

      var html = link;
      HtmlWeb web = new HtmlWeb();

      var htmlDoc = web.Load(html);
      //var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='rightContent']/div[2]/text()[5]");
      var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='rightContent']/div[2]/text()[5]");

      string statomanga = null;
      statomanga = htmlNodes.ToString();

      //foreach (var node in htmlNodes)
      //{
      // if (node.InnerHtml==("Stato"))

      //    return node.Attributes[""].ToString();

      //}

      //StringBuilder sb = new StringBuilder();
      //foreach (HtmlAgilityPack.HtmlTextNode node in
      //      htmlDoc.DocumentNode.SelectNodes("//div[@class='rightBox']/h4/"))
      //{
      //  sb.Append(node.Text.Trim());
      //}
      //string s = sb.ToString();

      return statomanga;
    }

    private static string GetNameManga(string link)
    {

      var html = link;
      HtmlWeb web = new HtmlWeb();

      var htmlDoc = web.Load(html);
      string htmlNodes = htmlDoc.DocumentNode
        .SelectNodes("//span[@class='manga-title']")
       .First()
            .InnerHtml;
      string name = null;
      name = (htmlNodes);
      //foreach (var node in htmlNodes)
      //{
      //  if (node.HasClass("chapterLink"))
      return name;
      ///TextBox2.Text= (node.Attributes["href"].Value);

      //}

    }



    private static List<string> GetListPage(string link)
    {
      int lunghezza = 0;
      lunghezza = link.Count();
           
      var html2 = link.Remove(lunghezza - 2, 2);
      HtmlWeb web2 = new HtmlWeb();

      var htmlDoc2 = web2.Load(html2);

      var name2 = htmlDoc2.DocumentNode

             .SelectNodes("//select[@id='pageSelect']/option");

      
      List<string> listaCapitoli2 = new List<string>();

      foreach (var node in name2)
      {

        listaCapitoli2.Add(html2 + node.Attributes["data-page"].Value + "/");
      

      }
      return listaCapitoli2;
    
      
    }


    private static int GetNumberPage(string link)
    {
      int lunghezza = 0;
      lunghezza = link.Count();

      //var html2 = link.Remove(lunghezza - 2, 2);
      //HtmlWeb web2 = new HtmlWeb();

      //var htmlDoc2 = web2.Load(html2);

      //var html2 = link.Remove(lunghezza - 2, 2);
      //HtmlWeb web2 = new HtmlWeb();
      HtmlWeb web2 = new HtmlWeb();
      var htmlDoc2 = web2.Load(link);

      var name2 = htmlDoc2.DocumentNode
              .SelectSingleNode("//div[@id='pageInfo']");

      string verifica = "";
      

     

        verifica=name2.InnerText;
      verifica = verifica.Remove(0,5);

      return Convert.ToInt32(verifica);


    }

    private static string GetImageAddress(string link)
    {
      //var html3 = @"https://www.mangaeden.com/it/it-manga/maison-ikkoku/1/1/";
      var html3 = link;
      HtmlWeb web3 = new HtmlWeb();

      var htmlDoc3 = web3.Load(html3);

      var name3 = htmlDoc3.DocumentNode

             .SelectNodes("//img[@id='mainImg']");

      //TextBox1.Text = name.Remove(0, 1);

      //var htmlNodes2 = htmlDoc2.DocumentNode
      //  .SelectNodes("//select/option");
      List<string> listaCapitoli3 = new List<string>();
      string download = "";
      foreach (var node in name3)
      {

        listaCapitoli3.Add(node.Attributes["src"].Value);
        ///TextBox2.Text= (node.Attributes["href"].Value);
        download = (node.Attributes["src"].Value);
      }
      //listaCapitoli2.Reverse();
      return download;
      //foreach (string item in listaCapitoli3)
      //{
      //  TextBox2.Text += item + Environment.NewLine;
      //}

    }
    #endregion


    #region gestione eventi

    private void btnNuovaAnalisi_Click(object sender, EventArgs e)
    {
      txtLinkManga.Text = string.Empty;
      txtLinkManga.Enabled = true;
      pictureBox1.ImageLocation = null;
      chklstbxListaCapitoli.DataSource = null;
      btnInizia.Enabled = false;
      btnConfermaDownload.Enabled = false;
      lstbxListaPagine.Items.Clear();
      btnDeselectAll.Enabled = false;
      btnSelectAll.Enabled = false;
      groupBox1.Text = "Titolo Manga";
      lblNumeroCapitoli.Text = "Numero Capitoli:";
      lblStato.Text = "Stato:";
      Manga = new List<MANGA>();
    }

    private void txtLinkManga_TextChanged(object sender, EventArgs e)
    {
      if (txtLinkManga.TextLength <= 20)
      {
        btnScarica.Enabled = false;
      }
      else btnScarica.Enabled = true;
    }

    private void btnIndirizzoSalva_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.ShowNewFolderButton = false;
      DialogResult result = this.folderBrowserDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        txtIndirizzoSalva.Text = folderBrowserDialog1.SelectedPath;
        AddUpdateAppSettings("indirizzosalvataggio", folderBrowserDialog1.SelectedPath);
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < chklstbxListaCapitoli.Items.Count; i++)
      {
        chklstbxListaCapitoli.SetItemChecked(i, true);
      }
     
      btnConfermaDownload.Enabled = true;
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < chklstbxListaCapitoli.Items.Count; i++)
      {
        chklstbxListaCapitoli.SetItemChecked(i, false);
      }
   
      btnConfermaDownload.Enabled = false;
    }



    private void chkOrdinamento_CheckedChanged(object sender, EventArgs e)
    {
      if (chkOrdinamento.Checked)
      {
        AddUpdateAppSettings("ordinamentolista", "crescente");
      }
      else
      {
        AddUpdateAppSettings("ordinamentolista", "decrescente");
      }
    }
    private void btnScarica_Click(object sender, EventArgs e)
    {
    
      btnSelectAll.Enabled = true;
      btnDeselectAll.Enabled = true;
      btnScarica.Enabled = false;
      txtLinkManga.Enabled = false;
      //tabControl1.Visible = false;
      //MessageBox.Show(ReadSetting("ordinamentolista"));
      pictureBox1.ImageLocation = GetImageManga(txtLinkManga.Text);
      //groupBox1.Text = GetNameManga(txtLinkManga.Text);
      OttieniListaCapitoli(txtLinkManga.Text);
   

      chklstbxListaCapitoli.DataSource = Manga;
      chklstbxListaCapitoli.DisplayMember = "NomeCapitolo";
      
    }

    void PopolaData()
    {

      for (int i = 0; i <= 800; i++)
      {
        Thread.Sleep(10);

      }
      //
      var html = txtLinkManga.Text;
      HtmlWeb web = new HtmlWeb();

      var htmlDoc = web.Load(html);
      var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//td/a[@class='chapterLink']");
      int contatore = 0;
      foreach (var node in htmlNodes)
      {
        MANGA oggetto = new MANGA();
               
        oggetto.Attivo = false;
        oggetto.LinkCapitolo = "Https://www.mangaeden.com" + node.Attributes["href"].Value;
        string ricerca = "Capitolo";
        int posizione = node.InnerText.IndexOf(ricerca);
        string stringafinale = node.InnerText;
        stringafinale = stringafinale.Substring(posizione);
        stringafinale = stringafinale.Replace("\n", " ");
        oggetto.NomeCapitolo = stringafinale;

        Manga.Add(oggetto);
      }

      //List<string> appoggio = new List<string>();
      //appoggio = GetListChapter(txtLinkManga.Text, true);

      //foreach (var contatore in appoggio)
      //{
      //  chklstbxListaCapitoli.Items.Add(contatore);
      //}
    }

    protected void lstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
    {
      int numerofile = 0;
      string nomefile = "";
      List<string> listaDownload = new List<string>();
      //listaDownload = GetListPage("https://" + lstbxListaCapitoli.SelectedValue);

      //lstbxListaLinkDownload.DataSource = listaDownload;
      //// lstbxListaLinkDownload.DataBind();
      // foreach (string item in listaDownload)
      // {
      //   numerofile++;
      //   nomefile = "https:" + GetImageAddress(item);
      //   DownloadRemoteImageFile(nomefile, "d:\\manga" + "\\" + trasformaCifre(numerofile) + ".jpg");
      //   System.Threading.Thread.Sleep(2000);
      // }
      // DownloadRemoteImageFile("https:" + download, "d:\\prova.jpg");
    }
    #endregion



    #region utility
    public static string TrasformaCifre(int num, int cifre)
    {

      string numeroDaStampare = num.ToString().PadLeft(cifre, '0');
      //ad ogni iterazione del ciclo : numeroDaStampare = 030 ; 029 ; 028 ... 009 ; 008 ecc.

      return numeroDaStampare;
    }

    public static bool ToBoolMio(string value)
    {
      switch (value.ToLower())
      {
        case "decrescente":
          return false;
        case "crescente":
          return true;
        default:
          return false;

      }
    }

    public void InizializzaControlli()
    {
      txtLinkManga.Text = "https://www.mangaeden.com/it/it-manga/maison-ikkoku/";
      tabControl1.TabPages[0].Text = "MangaEdenNETDownloader";
      tabControl1.TabPages[1].Text = "Opzioni";
      tabControl1.TabPages[2].Text = "Informazioni";
      string path = ReadSetting("indirizzosalvataggio");
      if (path == string.Empty) { path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
      folderBrowserDialog1.SelectedPath = path;
      txtIndirizzoSalva.Text = path;
      //chkOrdinamento.Checked= ToBoolMio( ReadSetting("ordinamentolista"));
      //folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    }

    static void ReadAllSettings()
    {
      try
      {
        var appSettings = ConfigurationManager.AppSettings;

        if (appSettings.Count == 0)
        {
          Console.WriteLine("AppSettings is empty.");
        }
        else
        {
          foreach (var key in appSettings.AllKeys)
          {
            //Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
          }
        }
      }
      catch (ConfigurationErrorsException)
      {
        //Console.WriteLine("Error reading app settings");
      }
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








    #endregion



    private void btnConfermaDownload_Click(object sender, EventArgs e)
    {
      tabControl1.SelectTab(1);
      chklstbxListaCapitoli.Enabled = false;
      btnSelectAll.Enabled = false;
      btnDeselectAll.Enabled = false;
      btnConfermaDownload.Enabled = false;
      List<string> listaImmagini = new List<string>();


      foreach (var item in Manga)
      {
        if (item.Attivo==true)
        {
          listaImmagini = GetListPage(item.LinkCapitolo);
          foreach (string lista in listaImmagini)
          {
            
            lstbxListaPagine.Items.Add(lista);
          }

        }
      }
      btnInizia.Enabled = true;

    }

    private void button1_Click(object sender, EventArgs e)
    {
      int numerofile = 0;
      int incremento = 0;
      string indirizzoSalvataggio = "";
      button1.Enabled = false;
      progressBar1.Visible = true;
      lblDownload.Visible = true;
      incremento = (lstbxListaPagine.Items.Count / 100);
      if (incremento == 0)
      {
        incremento = 1;
      }
      progressBar1.Maximum = lstbxListaPagine.Items.Count;
      foreach (string conta in lstbxListaPagine.Items)
      {
        int lunghezza = conta.Count();

        string conta2=conta.Remove(lunghezza - 2, 2);
        int posizione = Manga.FindIndex(x => x.LinkCapitolo.Contains(conta2));
       
        if (!Directory.Exists(ReadSetting("indirizzosalvataggio") + "\\"+ Manga.ElementAt(posizione).NomeCartella + "\\"))
        {
          Directory.CreateDirectory(ReadSetting("indirizzosalvataggio") + "\\" + Manga.ElementAt(posizione).NomeCartella + "\\");
        }
        
        numerofile++;
        indirizzoSalvataggio=  ReadSetting("indirizzosalvataggio") + "\\" + Manga.ElementAt(posizione).NomeCartella + "\\"+ TrasformaCifre(numerofile, 6) + ".jpg";
        // lblDownload.Text="Sto scaricando il file" + numerofile.ToString()+ "di" + lstbxListaPagine.Items.Count;
        DownloadRemoteImageFile("https:" + GetImageAddress(conta), indirizzoSalvataggio);

        progressBar1.Increment(incremento);
        posizione = 0;
        System.Threading.Thread.Sleep(2000);


      }
      progressBar1.Visible = false;
      lblFatto.Visible = true;

    }

    private void button1_Click_1(object sender, EventArgs e)
    {

    }

    private void button1_Click_2(object sender, EventArgs e)
    {



    }

    private void chklstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (chklstbxListaCapitoli.CheckedItems.Count > 0) btnConfermaDownload.Enabled = true;
      else btnConfermaDownload.Enabled = false;
      
    }

    


private void button2_Click(object sender, EventArgs e)
    {
      int ciao = 0;
      ciao=GetNumberPage(textBox1.Text);
    }

    private void chklstbxListaCapitoli_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      int position = 0;

      position=chklstbxListaCapitoli.SelectedIndex;
      Manga.ElementAt(position).Attivo = true;
      Manga.ElementAt(position).NomeCartella = "ch00"+(Manga.Count-position).ToString();
    }

    private void label4_Click(object sender, EventArgs e)
    {

    }
  }

}
