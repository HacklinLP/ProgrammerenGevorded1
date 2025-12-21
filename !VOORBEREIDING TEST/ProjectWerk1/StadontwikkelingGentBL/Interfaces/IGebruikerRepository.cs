using StadontwikkelingGentBL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Interfaces
{
    public interface IGebruikerRepository
    {
        public void VoegGebruikerIn(Gebruiker gebruiker);
        public void UpdateGebruiker(Gebruiker gebruiker);
        public void VerwijderGebruiker(Gebruiker gebruiker);
        public Gebruiker GeefGebruikerOpEmail(string email);
        public bool BestaatEmail(string email);
        List<Gebruiker> GeefAlleGebruikers();
    }
}
