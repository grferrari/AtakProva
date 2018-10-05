using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;

namespace SearchAPI.Models
{
    public class LinkSearch
    {
        /*
         * Entrada: parte do download da página do google {string file}.
         * Saída: Lista de links e titulos encontrados {List<SiteData> list}.
         */
        public static List<SiteData> find(string file)
        {
            List<SiteData> list = new List<SiteData>();

            // Procura correspondencias a tag <a> html.
            MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                SiteData i = new SiteData();

                //Filtra links de pesquisa do google.
                Match m2 = Regex.Match(value, @"(http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?)", RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value.Replace("&amp", "");
                }

                //Filtra titulos de pesquisa do google.
                i.Text = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);

                list.Add(i);
            }
            return list;
        }
    }
}