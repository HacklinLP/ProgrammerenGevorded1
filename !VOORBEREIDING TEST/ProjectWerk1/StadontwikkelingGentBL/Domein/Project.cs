using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadontwikkelingGentBL.Exceptions;

namespace StadontwikkelingGentBL.Domein
{
    public class Project
    {
        public Project(string titel, DateTime? startDatum, StatusProject status, string beschrijving, Adres locatie, List<Partner> partners, List<TypeProject> projectTypes)
        {
            Titel = titel;
            StartDatum = startDatum;
            Status = status;
            Beschrijving = beschrijving;
            Locatie = locatie;
            _partners = partners;
            _projectTypes = projectTypes;

        }

        public Project(int id, string titel, DateTime? startDatum, StatusProject status, string beschrijving, Adres locatie, List<Partner> partners, List<TypeProject> projectTypes)
        {
            Id = id;
            Titel = titel;
            StartDatum = startDatum;
            Status = status;
            Beschrijving = beschrijving;
            Locatie = locatie;
            _partners = partners;
            _projectTypes = projectTypes;

        }

        public void VoegPartnerToe(Partner partner)
        {
            _partners.Add(partner);
        }
        public int Id { get; init; }
        private string _titel;
        public string Titel 
        { 
            get => _titel;
            set 
            {
                if (!string.IsNullOrWhiteSpace(value)) _titel = value;
                else throw new ProjectException("Titel niet geldig!");
            }
        }
        private DateTime? _startDatum;
        public DateTime? StartDatum 
        { 
            get => _startDatum;
            set
            {
                DateTime now = DateTime.Now;
                //if (!(DateTime.Compare(now, value) < 0)) _startDatum = value;
                //else throw new ProjectException("Datum niet geldig!");
            } 
        }        
        public StatusProject Status { get; set; }
        private string _beschrijving;
        public string Beschrijving 
        { 
            get=> _beschrijving;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _beschrijving = value;
                else throw new ProjectException("Bescrhijving is niet geldig");
            }
        }
        public Adres Locatie { get; set; }

        private List<Partner> _partners;

        public IReadOnlyList<Partner> Partners => _partners; 

        private List<TypeProject> _projectTypes;
        public IReadOnlyList<TypeProject> ProjectTypes => _projectTypes;
    }
}
