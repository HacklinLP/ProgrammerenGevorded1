using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Adres
    {
        public string Straatnaam {  get; set; }
        public int Huisnummer { get; set; }
        public int Postcode { get; set; }
        public string Stad {  get; set; }

        public Adres(string straatnaam, int huisnummer, int postcode, string stad)
        {
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Stad = stad;
        }
    }
}
