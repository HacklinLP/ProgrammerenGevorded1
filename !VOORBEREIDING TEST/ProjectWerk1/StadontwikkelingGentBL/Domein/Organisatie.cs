using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public class Organisatie : Partner
    {
        public Organisatie(string naam, string email, string telNummer, string typePartner, List<string> rollen) : base(naam, email, telNummer, typePartner, rollen)
        {
        }

        public Organisatie(int id, string naam, string email, string telNummer, string typePartner, List<string> rollen) : base(id, naam, email, telNummer, typePartner, rollen)
        {
        }
    }
}
