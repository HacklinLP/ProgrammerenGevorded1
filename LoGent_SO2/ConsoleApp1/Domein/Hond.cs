using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logent.Domein
{
    public class Hond : Huisdier
    {
        public Grootte Grootte { get; set; }

        public Hond(DateTime geboortedatum, Persoon eigenaar, Grootte grootte, Adres woning ) : base(geboortedatum, eigenaar, woning)
        {
            this.Geboortedatum = geboortedatum;
            this.Eigenaar = eigenaar;
            this.Grootte = grootte;
        }

        public Huisdier Huisdier { get; set; }

        public bool IsKindvriendelijk()
        {
            throw new NotImplementedException();
        }

    }
}
