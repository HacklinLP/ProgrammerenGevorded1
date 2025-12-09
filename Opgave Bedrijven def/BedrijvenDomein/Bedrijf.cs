using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenDomein
{
    public class Bedrijf
    {
        public Bedrijf(string naam, string sector, string industrie, string extraInfo, string hoofdkwartier, int jaarOprichting, List<Personeel> personeel)
        {
            Naam = naam;
            Sector = sector;
            Industrie = industrie;
            ExtraInfo = extraInfo;
            Hoofdkwartier = hoofdkwartier;
            JaarOprichting = jaarOprichting;
            if (personeel == null || personeel.Count() < 1) throw new BedrijfException("personeel niet ok.");
            this.Personeel = personeel;
        }

        

        public string Naam { get; set; }
        public string Sector { get; set; }
        public string Industrie { get; set; }

        public string ExtraInfo { get; set; }

        public string Hoofdkwartier { get; set; }


        public int JaarOprichting { get; set; }

        public List<Personeel> Personeel;

        public IReadOnlyList<Personeel> Personeel
        {
            get { return personeel; }

        }
        public void AddPersoneel(Personeel personeel)
        {
            if
        }
    }
}
