using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HtmlAgilityPack;

public partial class Default2 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    txtLinkManga.Text= "https://www.mangaeden.com/it/it-manga/maison-ikkoku/";
    //DownloadRemoteImageFile("https:"+download, "d:\\prova.jpg");

  }
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
  private static int GetNumberOfChapter(string link)
  {

      var html = link;
    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(html);

    string name = htmlDoc.DocumentNode
           .SelectNodes("//tbody/tr")
             .First()
           .Attributes["id"].Value;

    //TextBox1.Text = name.Remove(0, 1);

    return Convert.ToInt32(name.Remove(0, 1));
  }

  private static List<string> GetListChapter(string link) {
   
    var html = link;
    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(html);
    var htmlNodes = htmlDoc.DocumentNode
      .SelectNodes("//td/a");
    List<string> listaCapitoli = new List<string>();

    foreach (var node in htmlNodes)
    {
      if (node.HasClass("chapterLink"))
        listaCapitoli.Add("www.mangaeden.com" + node.Attributes["href"].Value);
      ///TextBox2.Text= (node.Attributes["href"].Value);

    }
    listaCapitoli.Reverse();
    return listaCapitoli;
    
    
  }
  private static List<string> GetListPage(string link)
  {
    int lunghezza = 0;
    lunghezza=link.Count();

    var html2 = link.Remove(lunghezza-2,2);
    HtmlWeb web2 = new HtmlWeb();

    var htmlDoc2 = web2.Load(html2);

    var name2 = htmlDoc2.DocumentNode

           .SelectNodes("//select[@id='pageSelect']/option");

    //TextBox1.Text = name.Remove(0, 1);

    //var htmlNodes2 = htmlDoc2.DocumentNode
    //  .SelectNodes("//select/option");
    List<string> listaCapitoli2 = new List<string>();

    foreach (var node in name2)
    {

      listaCapitoli2.Add(html2 + node.Attributes["data-page"].Value+"/");
      ///TextBox2.Text= (node.Attributes["href"].Value);

    }
    return listaCapitoli2;
    //listaCapitoli2.Reverse();
    //foreach (string item in listaCapitoli2)
    //{
    //  TextBox2.Text += item + Environment.NewLine;
    //}



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

  protected void btnScarica_Click(object sender, EventArgs e)
  {
    lblNumeroCapitoli.Text = "Capitoli:"+ GetNumberOfChapter(txtLinkManga.Text).ToString();
    lstbxListaCapitoli.DataSource = GetListChapter(txtLinkManga.Text);
    lstbxListaCapitoli.DataBind();
   
  }

  protected void lstbxListaCapitoli_SelectedIndexChanged(object sender, EventArgs e)
  {
    int numerofile =0;
    string nomefile = "";
    List<string> listaDownload = new List<string>();
    listaDownload= GetListPage("https://" + lstbxListaCapitoli.SelectedValue);

    lstbxListaLinkDownload.DataSource = listaDownload;
      lstbxListaLinkDownload.DataBind();
    foreach (string item in listaDownload){
      numerofile++;
      nomefile ="https:"+ GetImageAddress(item);
      DownloadRemoteImageFile(nomefile, "d:\\manga"+"\\"+trasformaCifre(numerofile)+".jpg");
      System.Threading.Thread.Sleep(3000);
    }
   // DownloadRemoteImageFile("https:" + download, "d:\\prova.jpg");
  }
  public static string trasformaCifre(int num)
  {
  
      string numeroDaStampare = num.ToString().PadLeft(6, '0');
      //ad ogni iterazione del ciclo : numeroDaStampare = 030 ; 029 ; 028 ... 009 ; 008 ecc.
   
    return numeroDaStampare;
  }
}



