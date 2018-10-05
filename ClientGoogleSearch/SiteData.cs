using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGoogleSearch
{
    public class SiteData
    {
        public string text;
        public string href;

        public SiteData() { }

        public string Href
        {
            get
            {
                return href;
            }

            set
            {
                href = value;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }
    }
}
