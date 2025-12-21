using StadontwikkelingGentBL.Exceptions;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public abstract class Partner
    {
        public Partner(string naam, string email, string telNummer, string typePartner, List<string> rollen)
        {
            Naam = naam;
            Email = email;
            Telefoonnummer = telNummer;
            Type_Partner = typePartner;
            _rollen = rollen;
        }

        public Partner(int id, string naam, string email, string telNummer, string typePartner, List<string> rollen)
        {
            Id = id;
            Naam = naam;
            Email = email;
            Telefoonnummer = telNummer;
            Type_Partner = typePartner;
            _rollen = rollen;
        }

        public int Id { get; private set; }

        private string _naam;
        public string Naam
        {
            get => _naam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _naam = value;
                else throw new PartnerException("Naam niet geldig");
            }
        }
        private string _telNummer;
        public string Telefoonnummer 
        { 
            get => _telNummer;
            set
            {
                // lijkt logisch dat duitse bedrijven hier iets komen doen en die hebben een minimum lengte van 6 en maximum van 13
                if (!string.IsNullOrWhiteSpace(value))
                {
                    string shaved = value.Trim();
                    if (shaved.Length >= 6 && shaved.Length <= 13)
                    {
                        if (shaved[0] == '+' || shaved[0] == '0')
                        {
                            _telNummer = shaved;
                        }
                        else throw new PartnerException("Telefoonnummer begint niet met + of 0");
                    }
                    else throw new PartnerException("Telefoonnummer valt buiten de minimum en maximum grootte");
                }
                else throw new PartnerException("Telefoonnummer valt buiten de minimum en maximum grootte");
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    //emails kunnen maar 1 @ hebben dus check ik of er eentje in zit met split, en als ik een array van 2 terugkrijg is het ok
                    string[] splits = value.Split('@');
                    if (splits.Length == 2)
                    {
                        string[] splits2 = splits[1].Split('.');
                        if (splits2.Length >= 2)
                        {
                            string lowercaseEmail = value.ToLower();
                            _email = lowercaseEmail;
                        }
                        else throw new PartnerException("Email niet geldig");
                    }
                    else throw new PartnerException("Email niet geldig");
                }
                else throw new PartnerException("Email niet geldig");
            }
        }
        public string Type_Partner { get; set; }

        private List<string> _rollen;
        public IReadOnlyList<string> Rollen => _rollen;
    }
}
