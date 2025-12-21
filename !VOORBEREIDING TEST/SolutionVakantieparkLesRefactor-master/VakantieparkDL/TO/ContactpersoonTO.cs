using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieparkDL.TO
{
    public class ContactpersoonTO
    {
        public ContactpersoonTO(int iD, string naam, string email, string telefoon)
        {
            Id = iD;
            Naam = naam;
            Email = email;
            Telefoon = telefoon;
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
    }
}
