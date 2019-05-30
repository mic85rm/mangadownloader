using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaEdenNETDownloader
{
  class MANGA
  {
    public bool Attivo { get; set; }
    public string NomeCapitolo { get; set; }
    public string LinkCapitolo { get ; set; }
    public int NumeroPagine{ get; set; }
    public List<string>  ListaLinkImmagini { get; set; }

    public string NomeCartella { get; set; }
  }

  

}
