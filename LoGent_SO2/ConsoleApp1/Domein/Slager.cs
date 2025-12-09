using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Slager : Volwassene
    {
        public Slager(string naam, DateTime geboortedatum, string foto, List<Huisdier> huisdieren, Adres woning) : base(naam, geboortedatum, foto, huisdieren, woning)
        {

        }


    }
}
