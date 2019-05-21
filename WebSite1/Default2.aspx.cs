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
    var html = @"http://www.google.com/";

    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(html);

    var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

    TextBox1.Text=("Node Name: " + node.Name + "\n" + node.OuterHtml);
  }
}



