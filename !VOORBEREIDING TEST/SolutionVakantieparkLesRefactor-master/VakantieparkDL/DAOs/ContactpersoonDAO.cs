using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkDL.TO;

namespace VakantieparkDL.DAOs
{
    public class ContactpersoonDAO
    {
        private int contactpersoonId = 1;
        private Dictionary<int, ContactpersoonTO> contactpersonen = new();

        public ContactpersoonDAO()
        {
            contactpersonen.Add(contactpersoonId, new ContactpersoonTO(contactpersoonId, "jos", "jos@gmail.com", "01234566")); contactpersoonId++;
            contactpersonen.Add(contactpersoonId, new ContactpersoonTO(contactpersoonId, "julie", "julie@gmail.com", "012345669")); contactpersoonId++;
        }

        public ContactpersoonTO GeefContactpersoon(int contactpersoonId)
        {
            return contactpersonen[contactpersoonId];
        }
    }
}
