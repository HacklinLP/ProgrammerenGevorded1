
using KlantenSimulatorBL.Interfaces;
using KlantenSimulatorBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantenSimulatorDL
{
    public class BestandsSchrijver : IBestandsschrijver
    {
        public void SchrijfBestand(List<Persoon> data, string pad)
        {
            using (StreamWriter sw = new StreamWriter(pad))
            {
                foreach (Persoon p in data)
                {
                    sw.WriteLine(pad.ToString());
                }
            }
        }
    }
}
