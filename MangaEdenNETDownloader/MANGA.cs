using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaEdenNETDownloader
{
  class MANGA
  {
    public int Posizione { get; set; }
    public string NomeCapitolo { get; set; }
    public string LinkCapitolo { get; set; }

    public List<string>  ListaPagine { get; set; }
  }
}
