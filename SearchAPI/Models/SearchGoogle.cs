using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace SearchAPI.Models
{
    public class SearchGoogle
    {
        public List<SiteData> Final { get; set; }

        public SearchGoogle() { }

        /*
         * Contrutor responsável por armazenar página de pesquisa do 
         * google e filtrar todos os links e titulos relevantes.
         * 
         * Entrada: texto da pesquisa {string text}.
         */
        public SearchGoogle(String text)
        {
            Final = new List<SiteData>();
            WebClient client = new WebClient();
            Uri url = new Uri("https://www.google.com.br/search?q=" + text);
            string s = client.DownloadString(url);
            foreach (SiteData i in LinkSearch.find(s))
            {
                if (i != null)
                {
                    if (i.Href != null)
                    {
                        if (!i.Href.Contains("google"))
                        {
                            Final.Add(i);
                        }
                    }
                }
            }
        }
    }
}