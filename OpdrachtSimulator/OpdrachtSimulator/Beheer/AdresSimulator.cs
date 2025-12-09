using KlantenSimulatorBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantenSimulatorBL.Beheer
{
    public class AdresSimulator
    {
        private Random random = new Random();
        private List<string> straatnamen = new();
        private List<(int postcode, string gemeente)> postcodeGemeente = new();
        private int maxHuisnummer;
        private int percentLetter;

        public AdresSimulator(List<string> straatnamen, List<(int postcode, string gemeente)> postcodeGemeente, int maxHuisnummer, int percentLetter)
        {
            this.straatnamen = straatnamen;
            this.postcodeGemeente = postcodeGemeente;
            this.maxHuisnummer = maxHuisnummer;
            this.percentLetter = percentLetter;
        }

        public List<Adres> GeefAdressen (int aantal)
        {
            List<Adres> adressen = new();

            return adressen;
        }

        private string GeefHuisnummer()
        {
            int nummer = random.Next(1,maxHuisnummer);
            if (random.Next(101) <= percentLetter)
            {
                return $"{nummer}{random.Next('a', 'r' + 1)}";
            }
            return $"{nummer}";
        }
    }
}
