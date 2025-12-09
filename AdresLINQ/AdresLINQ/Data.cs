using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresLINQ
{
    public class Data
    {
        public string Provincie { get; set; }

        public string Gemeente { get; set; }

        public string Straatnaam { get; set; }

        public Data(string provincie, string gemeente, string straatnaam)
        {
            this.Provincie = provincie;
            this.Gemeente = gemeente;
            this.Straatnaam = straatnaam;
        }

        public override string ToString()
        {
            return $"{Provincie},{Gemeente},{Straatnaam}";
        }
    }
}
