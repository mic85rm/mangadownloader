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
    //var html = @"https://www.mangaeden.com/it/it-manga/ranma-frac12/";
    var html = @"https://www.mangaeden.com/it/it-manga/maison-ikkoku/";
    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(html);

    string name = htmlDoc.DocumentNode
           .SelectNodes("//tbody/tr")
             .First()
           .Attributes["id"].Value;

    TextBox1.Text= name.Remove(0, 1);

   

    

    Console.WriteLine(name);
  }
}



