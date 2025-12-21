using StadontwikkelingGentBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public class GroeneRuimteProject : TypeProject
    {
        public GroeneRuimteProject( double oppervlakteVierkanteM, int biodiversiteitsScore, int aantalWandelpaden, List<Faciliteit> beschikbareFaciliteiten, bool isOpgenomenInWandelroute, int? beoordelingBezoekers)
        {
            OppervlakteVierkanteM = oppervlakteVierkanteM;
            BiodiversiteitsScore = biodiversiteitsScore;
            AantalWandelpaden = aantalWandelpaden;
            IsOpgenomenInWandelroute = isOpgenomenInWandelroute;
            BeoordelingBezoekers = beoordelingBezoekers;
            Faciliteiten = beschikbareFaciliteiten;
        }
        public GroeneRuimteProject(int ID, double oppervlakteVierkanteM, int biodiversiteitsScore, int aantalWandelpaden, List<Faciliteit> beschikbareFaciliteiten, bool isOpgenomenInWandelroute, int? beoordelingBezoekers) : base( ID)
        {
            OppervlakteVierkanteM = oppervlakteVierkanteM;
            BiodiversiteitsScore = biodiversiteitsScore;
            AantalWandelpaden = aantalWandelpaden;
            IsOpgenomenInWandelroute = isOpgenomenInWandelroute;
            BeoordelingBezoekers = beoordelingBezoekers;
            Faciliteiten = beschikbareFaciliteiten;
        }
        private List<Faciliteit> _faciliteiten;
        public List<Faciliteit> Faciliteiten { 
            get=> _faciliteiten; 
            set
            {
                _faciliteiten = value;
            }
        }
        private double _oppervlakte;
        public double OppervlakteVierkanteM 
        {
            get => _oppervlakte;
            set
            {
                if (!(value <= 0)) _oppervlakte = value;
                else throw new ProjectException("Oppervlakte ongeldig!");
            }
        }
        private int _score;
        public int BiodiversiteitsScore 
        { 
            get => _score;
            set
            {
                if (!(value < 0) && !(value > 10)) _score = value;
                else throw new ProjectException("Biodiversiteitsscore niet geldig!");
            }
        }
        private int _wandelpaden;
        public int AantalWandelpaden 
        { 
            get => _wandelpaden;
            set
            {
                if (!(value < 0)) _wandelpaden = value;
                else throw new ProjectException("Aantal Wandelpaden niet OK");
            }
        }
        private bool _wandelroute;
        public bool IsOpgenomenInWandelroute 
        { 
            get => _wandelroute;
            set
            {
                if (value == null) _wandelroute = false;
                else _wandelroute = value;
            }
        }
        private int? _beoordeling;
        public int? BeoordelingBezoekers 
        { 
            get => _beoordeling;
            set
            {
                if (value.HasValue)
                {
                    if (!(value.Value < 0) && !(value.Value > 5)) _beoordeling = value.Value;
                    else throw new ProjectException("Beoordeling bezoekers niet geldig!");
                }
                else _beoordeling = null;
            }
        }
    }
}
