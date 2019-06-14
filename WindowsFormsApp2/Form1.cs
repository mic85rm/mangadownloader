using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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


    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      
      CaricaListaManga("https://www.mangaeden.com/api/list/1/");
      InizializzaComboBox();
      
    }

   

    public void InizializzaComboBox()
    {
      comboBox1.DataSource= listamanga.manga;
      comboBox1.DisplayMember = "t";
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
        //paginacapitoli = JsonConvert.DeserializeObject<PaginaCapitoli>(json);
        //DataTable table = ConvertListToDataTable(paginacapitoli.chapters);
        
        //foreach (var sublist in paginacapitoli.chapters)
        //{
                   
        //    foreach (var value in sublist)
        //  {
          
        //      }
          
        //}
        JObject googleSearch = JObject.Parse(json);
        IList<JToken> results = googleSearch["chapters"].Children().ToList();
        
        data = ConvertListToDataTable(results);
        //JsonTextReader reader = new JsonTextReader(new StringReader(json));
        //while (reader.Read())
        //{
        //  if (reader.Value != null)
        //  {
        //    if (String.Compare(reader.Value.ToString(), "chapters") == 0) {
        //      Console.WriteLine("Token: {0}, Value: {1}, ciao", reader.TokenType, reader.Value);
        //    }


        //  //if (reader.Value == "chapters")
        //  //{
        //  // Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
        //  }
        //  //else
        //  //{
        //   // Console.WriteLine("Token: {0}", reader.TokenType);
        ////  }
        //}

        //IList<CAPITOLI> searchResults = new List<CAPITOLI>();
        ////foreach (JToken result in results)

        ////{
        ////  // JToken.ToObject is a helper method that uses JsonSerializer internally
        ////  CAPITOLI searchResult = result.Select(x=>x.);
        ////  searchResults.Add(searchResult);
        ////}
      }
      catch (Exception ex) {
       
        MessageBox.Show(ex.ToString());
      }
    }




    private void chklstbxListaManga_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

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
       string appoggio = array.ToString().Replace("\n","").Replace("\r","").Replace(@"""","").Replace("[","").Replace("]", "");
        string[] ciao=appoggio.Split(',');
        
        for (int i = 0; i<ciao.Count(); i++)
        {
          ciao[i] = ciao[i].TrimStart(' ');
        }
        appoggio = ciao.ToString();
        
        table.Rows.Add(ciao);
      }
      foreach(DataRow row in table.Rows)
      {
        row["Column5"] = row["Column1"].ToString() + row["Column3"].ToString();
      }
   


      return table;
    }


    public void popolacls(DataTable dt)
    {

      checkedListBox1.DataSource = null;
      DataSet ds = new DataSet();
      
      ds.Tables.Add(dt);
      
      BindingSource bs = new BindingSource();
      bs.DataSource = ds;
      bs.DataMember = "Table1";

      checkedListBox1.DataSource = bs;
      checkedListBox1.DisplayMember = "Column5";
     
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {      
      pictureBox1.ImageLocation = "https://cdn.mangaeden.com/mangasimg/200x/" + listamanga.manga.ElementAt(comboBox1.SelectedIndex).im;
      CaricaListaCapitoli("https://www.mangaeden.com/api/manga/", listamanga.manga.ElementAt(comboBox1.SelectedIndex).i);

     // DataTable table = ConvertListToDataTable(paginacapitoli.chapters);
      popolacls(data);
    }
   



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
        listaimmagini= ConvertToList(results);

      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.ToString());
      }
    }


    private void button1_Click(object sender, EventArgs e)
    {
      CreazioneCodaDownload("https://www.mangaeden.com/api/chapter/", data.Rows[checkedListBox1.SelectedIndex][3].ToString());
    }


    public  List<string> ConvertToList(IList<JToken> list)
    {
       

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

        //table.Rows.Add(ciao);
      }
   



      return listaimmagini;
    }
  }
}
