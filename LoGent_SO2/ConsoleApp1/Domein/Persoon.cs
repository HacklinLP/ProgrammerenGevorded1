using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Persoon
    {
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Foto { get; set; }

        public List<Huisdier> Huisdieren { get; set; }

        public Adres Woning { get; set; }


        public Persoon(string naam, DateTime geboortedatum, string foto, List<Huisdier> huisdieren, Adres woning)
        {
            Naam = naam;
            Geboortedatum = geboortedatum;
            Foto = foto;
            Huisdieren = huisdieren;
            Woning = woning;
        }
    }
}
