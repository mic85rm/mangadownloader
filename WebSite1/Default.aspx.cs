using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
  
  protected void Page_Load(object sender, EventArgs e)
  {
    WebClient webClient = new WebClient();
    //webClient.Proxy = WebRequest.DefaultWebProxy;
    //webClient.Credentials = System.Net.CredentialCache.DefaultCredentials; ;
    //webClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    //string html = new WebClient().DownloadString("https://www.mangaeden.com/it/it-manga/ranma-frac12/");
    string html = webClient.DownloadString("https://www.mangaeden.com/it/it-manga/ranma-frac12/");
    TextBox2.Text = html;
  }

  protected void Bottone1_Click(object sender, EventArgs e)
  {
    DownloadRemoteImageFile(TextBox1.Text,"d:\\prova.jpg");
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
}