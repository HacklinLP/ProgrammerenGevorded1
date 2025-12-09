using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenDomein
{
    public class Personeel
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public DateTime GeboorteDatum { get; set; }
        private Adres _adres;
        public Adres Adres
        {
            get
            {
                return _adres;
            }
            set
            {
                if (value == null)
                {
                    throw new BedrijfException("Adres is null");
                }
            }
        }

        public Personeel(int id, string voornaam, string achternaam, string email, DateTime geboorteDatum, Adres adres)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            GeboorteDatum = geboorteDatum;
            Adres = adres;
        }

        public override string ToString()
        {
            return $"{Voornaam}, {Achternaam}, {Email}, {Adres}";
        }
    }
}
