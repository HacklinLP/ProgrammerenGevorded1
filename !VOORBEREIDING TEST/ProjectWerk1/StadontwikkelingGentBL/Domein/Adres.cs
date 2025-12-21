using StadontwikkelingGentBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public class Adres
    {
        public Adres(string straat, string huisnummer, string gemeente, string provincie, string wijk)
        {
            Straat = straat;
            Huisnummer = huisnummer;
            Gemeente = gemeente;
            Provincie = provincie;
            Wijk = wijk;
        }
        private string _straat;
        public string Straat
        {
            get => _straat;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _straat = value;
                else throw new AdresException("Straat niet geldig");
            }
        }
        private string _huisnummer;
        public string Huisnummer {
            get => _huisnummer;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _huisnummer = value;
                else throw new AdresException("Huisnummer niet geldig");
            }
        }
        private string _gemeente;
        public string Gemeente
        {
            get => _gemeente;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _gemeente = value;
                else throw new AdresException("Gemeente niet geldig");
            }
        }
        private string _provincie;
        public string Provincie
        {
            get => _provincie;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _provincie = value;
                else throw new AdresException("Provincie niet geldig");
            }
        }
        private string _wijk;
        public string Wijk
        {
            get => _wijk;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _wijk = value;
                else throw new AdresException("Wijk niet geldig");
            }
        }
    }
}
