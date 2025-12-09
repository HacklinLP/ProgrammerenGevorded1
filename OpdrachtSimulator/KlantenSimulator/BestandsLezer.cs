using KlantenSimulatorBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KlantenSimulatorDL
{
    //Belangrijk!!! Duidelijk hoe de StreamReader werkt
    public class BestandsLezer : IBestandslezer
    {
        public List<string> LeesNamen(string pad)
        {
            List<string> namen = new();
            using (StreamReader sr = new StreamReader(pad))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    namen.Add(line.Split(';')[1].Trim());
                }
            }
            return namen;
                
        }
        public List<(int postcode, string gemeente)> LeesPostcodeGemeente(string pad)
        {
            List<(int, string)> postcodeGemeente = new();
            using (StreamReader sr = new StreamReader(pad))
            {
                string line;
                sr.ReadLine(); // Eerste lijn van het bestand overslaan omdat het niet belangrijk is
                while ((line = sr.ReadLine()) != null)
                {
                    string[] ss = line.Split(";");
                    if (!string.IsNullOrWhiteSpace(ss[0]))
                        postcodeGemeente.Add((int.Parse(ss[0].Trim()), ss[1].Trim()));
                }
            }
            return postcodeGemeente;
        }
        public List<string> LeesStraten(string pad)
        {
            List<string> namen = new();
            using (StreamReader sr = new StreamReader(pad))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    namen.Add(line.Split(';')[2].Trim());
                }
                
            }
            return namen.Distinct().ToList();
        }

    }

}
