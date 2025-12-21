using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Exceptions;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public class Gebruiker
    {

        public Gebruiker(string naam, string email, string telnummer, bool isAdmin)
        {
            Naam = naam;
            Email = email;
            TelNummer = telnummer;
            IsAdmin =isAdmin;
        }

        public Gebruiker(int id, bool isAdmin, string naam, string email, string telNummer)
        {
            Id = id;
            IsAdmin = isAdmin;
            Naam = naam;
            Email = email;
            TelNummer = telNummer;
        }

        public Gebruiker(int id, bool isAdmin, List<ProjectDTOUi> gebrProjecten, string naam, string email, string telNummer)
        {
            Id = id;
            IsAdmin = isAdmin;
            _gebrProjectenDTO = gebrProjecten;
            Naam = naam;
            Email = email;
            TelNummer = telNummer;
        }

        public Gebruiker(int id, bool isAdmin, List<Project> gebrProjecten, string naam, string email, string telNummer)
        {
            Id = id;
            IsAdmin = isAdmin;
            GebrProjecten = gebrProjecten;
            Naam = naam;
            Email = email;
            TelNummer = telNummer;
        }

        public int Id { get; init; }
        public bool IsAdmin { get; set; }
        public List<Project> GebrProjecten { get; set; }
        private string _naam;
        public string Naam
        {
            get => _naam;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _naam = value;
                else throw new GebruikerException("Naam niet geldig");
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
                        else throw new GebruikerException("Email niet geldig");
                    }
                    else throw new GebruikerException("Email niet geldig");
                }
                else throw new GebruikerException("Email niet geldig");
            }
        }
        private string _telNummer;
        public string TelNummer
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
                        else throw new GebruikerException("Telefoonnummer begint niet met + of 0");
                    }
                    else throw new GebruikerException("Telefoonnummer valt buiten de minimum en maximum grootte");
                }
                else throw new GebruikerException("Telefoonnummer valt buiten de minimum en maximum grootte");
            }
        }
        public void VoegProjectToe(Project project)
        {
            throw new NotImplementedException();
        }

        private List<ProjectDTOUi> _gebrProjectenDTO { get; set; }

        public IReadOnlyList<ProjectDTOUi> GebrProjectenDTO => _gebrProjectenDTO;
    }
}
