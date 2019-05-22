using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HtmlAgilityPack;

public partial class Default2 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

    #region parte1
    var html = @"https://www.mangaeden.com/it/it-manga/maison-ikkoku/";
    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(html);

    string name = htmlDoc.DocumentNode
           .SelectNodes("//tbody/tr")
             .First()
           .Attributes["id"].Value;

    TextBox1.Text = name.Remove(0, 1);

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
    foreach (string item in listaCapitoli)
    {
      TextBox2.Text += item + Environment.NewLine;
    }



    Console.WriteLine(name);
    #endregion

    #region parte2

    var html2 = @"https://www.mangaeden.com/it/it-manga/maison-ikkoku/1/1/";
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
     
      listaCapitoli2.Add("https://www.mangaeden.com/it/it-manga/maison-ikkoku/1/" + node.Attributes["data-page"].Value);
      ///TextBox2.Text= (node.Attributes["href"].Value);

    }
    //listaCapitoli2.Reverse();
    foreach (string item in listaCapitoli2)
    {
      TextBox2.Text += item + Environment.NewLine;
    }



   
    #endregion

   
  }
}



