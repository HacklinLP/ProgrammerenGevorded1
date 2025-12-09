using KlantenSimulatorBL.Interfaces;
using KlantenSimulatorBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KlantenSimulatorBL.Beheer
{
    public class DataBeheerder
    {
        private PersoonSimulator persoonSimulator;
        private AdresSimulator adresSimulator;
        private IBestandslezer bestandsLezer;
        private IBestandsschrijver bestandsSchrijver;
        public DataBeheerder(IBestandslezer bestandslezer, IBestandsschrijver bestandsschrijver, int minLeeftijd, int maxLeeftijd, int minId, int maxId, string padVoornamenMannen, string padVoornamenVrouwen, string padFamilienamen, int percentLetter, int maxHuisnummer, string padStraten, string padPostcodeGemeente, int aantalAdressen)
        {
            this.bestandsLezer = bestandslezer;
            this.bestandsSchrijver = bestandsschrijver;

            var postcodeGemeente = bestandslezer.LeesPostcodeGemeente(padPostcodeGemeente);
            List<string> straten = bestandslezer.LeesStraten(padStraten);
            adresSimulator = new AdresSimulator(straten, postcodeGemeente,maxHuisnummer, percentLetter);

            List<Adres> adressen = adresSimulator.GeefAdressen(aantalAdressen);

            List<string> vn = bestandsLezer.LeesNamen(padVoornamenMannen);
            vn.AddRange(bestandsLezer.LeesNamen(padVoornamenVrouwen));
            List<string> fn = bestandsLezer.LeesNamen(padFamilienamen);
            persoonSimulator = new PersoonSimulator(vn,fn, adressen, minLeeftijd, maxLeeftijd, minId, maxId);
        }
        public void SimuleerPersonen(int aantal, string pad)
        {
            var data = persoonSimulator.MaakPersoon(aantal);
            bestandsSchrijver.SchrijfBestand(data, pad);
            
        }
    }
}
