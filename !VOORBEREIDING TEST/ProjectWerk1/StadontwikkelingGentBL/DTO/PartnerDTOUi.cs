using StadontwikkelingGentBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.DTO
{
    class PartnerDTOUi
    {

        public PartnerDTOUi(int id, string naam, string email, string telNummer, string typePartner)
        {
            Id = id;
            Naam = naam;
            Email = email;
            Telefoonnummer = telNummer;
            Type_Partner = typePartner;

        }

        public int Id { get; private set; }

        private string _naam;
        public string Naam
        {
            get => _naam;
            set
            {
               _naam = value;
            }
        }
        private string _telNummer;
        public string Telefoonnummer
        {
            get => _telNummer;
            set
            {

                _telNummer = value;
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                string lowercaseEmail = value.ToLower();
                _email = lowercaseEmail;
            }
        }
        public string Type_Partner { get; set; }


    }
}
