using KlantenSimulatorBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantenSimulatorBL.Beheer
{
    public class PersoonSimulator
    {

        private Random r = new Random();
        private List<string> _voornamen = new();
        private List<string> _familienamen = new();
        private List<Adres> _adressen = new();
        private int minLeeftijd, maxLeeftijd, minId, maxId;
        private List<string> _emailExtensie = new()
        {
            "gmail.com", "outlook.com", "hotmail.com", "yahoo.com", "telenet.be"
        };

        public PersoonSimulator(List<string> voornamen, List<string> familienamen, List<Adres> adressen, int minLeeftijd, int maxLeeftijd, int minId, int maxId)
        {
            _voornamen = voornamen;
            _familienamen = familienamen;
            _adressen = adressen;
            this.minLeeftijd = minLeeftijd;
            this.maxLeeftijd = maxLeeftijd;
            this.minId = minId;
            this.maxId = maxId;
        }

        public List<Persoon> MaakPersoon(int aantal)
        {
            HashSet<Persoon> data = new();
            int aantalGemaakt = 0;
            while (aantalGemaakt < aantal )
            {
                string voornaam = _voornamen[r.Next(_voornamen.Count())];
                string familienaam = _familienamen[r.Next(_familienamen.Count())];
                Persoon persoon = new(r.Next(minId, maxId),
                    voornaam,
                    familienaam,
                    MaakEmail(voornaam, familienaam),
                    MaakGeboortedatum(minLeeftijd, maxLeeftijd),
                    _adressen[r.Next(_adressen.Count())]);

                if(!data.Contains(persoon))
                {
                    aantalGemaakt++;

                    data.Add(persoon);
                }

            }

            return data.ToList();
        }
        private string MaakEmail(string voornaam, string familienaam)
        {
            return $"{voornaam.Replace(" ","").Replace("-","")}.{familienaam.Replace(" ","").Replace("-","")}@{_emailExtensie[r.Next(_emailExtensie.Count())]}";
        }
        private DateTime MaakGeboortedatum(int minLeeftijd, int maxLeeftijd)
        {
            DateTime now = DateTime.Now;
            DateTime min = now.AddYears(-minLeeftijd);
            DateTime max = now.AddYears(-maxLeeftijd);

            TimeSpan span = min - max;

            double range = span.TotalSeconds;

            return max.AddSeconds(r.NextDouble() * range);
        }
        

        
    }
}
