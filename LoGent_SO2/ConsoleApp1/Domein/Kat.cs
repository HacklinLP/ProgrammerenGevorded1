using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Kat : Huisdier
    {
        public Ras Ras;


        public Kat(DateTime geboortedatum, Persoon eigenaar, Adres woning, Ras ras) : base(geboortedatum, eigenaar, woning)
        {
            this.Geboortedatum = geboortedatum;
            this.Eigenaar = eigenaar;
            this.Ras = ras;
        }

        public bool HoudtVanMelk()
        {
            throw new NotImplementedException();
        }
    }
}
