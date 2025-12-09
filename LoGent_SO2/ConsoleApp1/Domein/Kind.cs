using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Kind : Persoon
    {
        public List<Volwassene> Ouders {  get; set; } = new List<Volwassene>();
        public Kind(string naam, DateTime geboortedatum, string foto, List<Huisdier> huisdieren, Adres woning, List<Volwassene> ouders) : base(naam, geboortedatum, foto, huisdieren, woning)
        {
            if (ouders == null || ouders.Count == 0)
                throw new ArgumentException("Een kind moet minstens 1 ouder hebben");
        }
    }
}
