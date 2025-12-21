using StadontwikkelingGentBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public class StadsOntwikkelingsProject : TypeProject
    {
        public StadsOntwikkelingsProject(VergunningStatus vergunStatus, bool heeftArchitectureleWaarde, OpenbareToegankelijkheid toegankelijkheid, bool isBezienswaardig, bool heeftUitlegbordOfInfoWandeling) 
        {
            VergunStatus = vergunStatus;
            HeeftArchitectureleWaarde = heeftArchitectureleWaarde;
            Toegankelijkheid = toegankelijkheid;
            IsBezienswaardig = isBezienswaardig;
            HeeftUitlegbordOfInfoWandeling = heeftUitlegbordOfInfoWandeling;
        }

        public StadsOntwikkelingsProject(int ID , VergunningStatus vergunStatus, bool heeftArchitectureleWaarde, OpenbareToegankelijkheid toegankelijkheid, bool isBezienswaardig, bool heeftUitlegbordOfInfoWandeling) : base(ID)
        {
            VergunStatus = vergunStatus;
            HeeftArchitectureleWaarde = heeftArchitectureleWaarde;
            Toegankelijkheid = toegankelijkheid;
            IsBezienswaardig = isBezienswaardig;
            HeeftUitlegbordOfInfoWandeling = heeftUitlegbordOfInfoWandeling;
        }
        public VergunningStatus VergunStatus { get; set; }
        private bool _waarde;
        public bool HeeftArchitectureleWaarde 
        { 
            get => _waarde; 
            set
            {
                if (value == null) _waarde = false;
                else _waarde = value;
            }
        }
        public OpenbareToegankelijkheid Toegankelijkheid { get; set; }
        private bool _bezien;
        public bool IsBezienswaardig 
        { 
            get => _bezien; 
            set
            {
                if (value == null) _bezien = false;
                else _bezien = value;
            }
        }
        private bool _uitleg;
        public bool HeeftUitlegbordOfInfoWandeling 
        { 
            get => _uitleg;
            set
            {
                if (value == null) _uitleg = false;
                else _uitleg = value;
            }
        }
    }
}
