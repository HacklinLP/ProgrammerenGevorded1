using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Huisdier
    {
        public DateTime Geboortedatum { get; set; }

        public Persoon Eigenaar { get; set; }

        public Adres Woning { get; set; }

        public Huisdier(DateTime geboortedatum, Persoon eigenaar, Adres woning)
        {

            Geboortedatum = geboortedatum;
            Eigenaar = eigenaar;
            Woning = woning;
        }

        public bool IsGevaccineerd()
        {
            Console.WriteLine("Het dier is gevaccineerd");
            throw new NotImplementedException();
        }
    }
}
