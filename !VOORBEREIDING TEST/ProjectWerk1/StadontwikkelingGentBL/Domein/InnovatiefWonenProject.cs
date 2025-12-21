using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadontwikkelingGentBL.Exceptions;

namespace StadontwikkelingGentBL.Domein
{
    public class InnovatiefWonenProject : TypeProject
    {
        public InnovatiefWonenProject(int aantalWooneenheden, List<Woonvorm> typeWoonvormen, bool isRondleidingMogelijk, bool isShowwoningBeschikbaar, int? architecturaleScore, bool heeftSamenwerkingErfgoedOfToerismeGent) 
        {
            AantalWooneenheden = aantalWooneenheden;
            TypeWoonvormen = typeWoonvormen;
            IsRondleidingMogelijk = isRondleidingMogelijk;
            IsShowwoningBeschikbaar = isShowwoningBeschikbaar;
            ArchitecturaleScore = architecturaleScore;
            HeeftSamenwerkingErfgoedOfToerismeGent = heeftSamenwerkingErfgoedOfToerismeGent;
        }
        public InnovatiefWonenProject(int ID, int aantalWooneenheden, List<Woonvorm> typeWoonvormen, bool isRondleidingMogelijk, bool isShowwoningBeschikbaar, int? architecturaleScore, bool heeftSamenwerkingErfgoedOfToerismeGent) : base (ID)
        {
            AantalWooneenheden = aantalWooneenheden;
            TypeWoonvormen = typeWoonvormen;
            IsRondleidingMogelijk = isRondleidingMogelijk;
            IsShowwoningBeschikbaar = isShowwoningBeschikbaar;
            ArchitecturaleScore = architecturaleScore;
            HeeftSamenwerkingErfgoedOfToerismeGent = heeftSamenwerkingErfgoedOfToerismeGent;
        }
        private int _aantalWooneenheden;
        public int AantalWooneenheden 
        { 
            get => _aantalWooneenheden;
            set
            {
                if (value > 0) _aantalWooneenheden = value;
                else throw new ProjectException("Aantal wooneenheden niet geldig!");
            }
        }
        private List<Woonvorm> _typeWoonvormen;
        public List<Woonvorm> TypeWoonvormen 
        { 
            get => _typeWoonvormen;
            set 
            {
                _typeWoonvormen = value;
                
            } 
        }
        private bool _rondleiding;
        public bool IsRondleidingMogelijk 
        { 
            get => _rondleiding;
            set
            {
                if (value == null) _rondleiding = false;
                else _rondleiding = value;
            }
        }
        private bool _showroom;
        public bool IsShowwoningBeschikbaar 
        {
            get => _showroom;
            set
            {
                if (value == null) _showroom = false;
                else _showroom = value;
            }
        }
        private int? _score; 
        public int? ArchitecturaleScore 
        { 
            get => _score;
            set
            {
                if(value.HasValue)
                {
                    if (!(value.Value < 0) && !(value.Value > 10)) _score = value;
                    else throw new ProjectException("Architecturale score niet geldig!");
                }else _score = null;
            }
        }
        private bool _samenwerking;
        public bool HeeftSamenwerkingErfgoedOfToerismeGent 
        {
            get => _samenwerking;
            set
            {
                if (value == null) _samenwerking = false;
                else _samenwerking = value;
            }
        }
    }
}
