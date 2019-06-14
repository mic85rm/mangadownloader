using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
  public class Manga
  {
    public string a { get; set; }
    public List<object> c { get; set; }
    public int h { get; set; }
    public string i { get; set; }
    public string im { get; set; }
    public double ld { get; set; }
    public int s { get; set; }
    public string t { get; set; }
  }

  public class ListaManga
  {
    public int end { get; set; }
    public List<Manga> manga { get; set; }
    public int page { get; set; }
    public int start { get; set; }
    public int total { get; set; }
  }

  public class PaginaCapitoli
  {
    public List<string> aka { get; set; }
    public List<string> akaalias { get; set; }
    public string alias { get; set; }
    public string artist { get; set; }
    public List<string> artist_kw { get; set; }
    public string author { get; set; }
    public List<string> author_kw { get; set; }
    public bool baka { get; set; }
    public List<string> categories { get; set; }
    public List<List<object>> chapters { get; set; }
    public int chapters_len { get; set; }
    public double created { get; set; }
    public string description { get; set; }
    public int hits { get; set; }
    public string image { get; set; }
    public int language { get; set; }
    public string last_chapter_date { get; set; }
    public List<double> random { get; set; }
    public int released { get; set; }
    public string startsWith { get; set; }
    public int status { get; set; }
    public string title { get; set; }
    public List<string> title_kw { get; set; }
    public int type { get; set; }
    public bool updatedKeywords { get; set; }
  }

  public class CAPITOLI
  {

    public string numeroCapitolo { get; set; }
    public string dataCapitolo { get; set; }
    public string nomeCapitolo { get; set; }

    public string idCapitolo { get; set; }

  }

}
