using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces {
    public class IProvincieBestandLezer
    {
        public List<Provincie> LeesBestanden(string folder, List<string> bestandsNamen)
        {
            HashSet<int> provincieIds = new();
            Dictionary<int, Provincie> provincies = new();
            using (StreamReader sr = new StreamReader(Path.Combine(folder, bestandsNamen[0])))
            {
                string[] line = sr.ReadLine().Split(',');
                foreach (string s in line)
                {
                    provincieIds.Add(int.Parse(s));
                }
                return null;
            }
            
        }
    }
}
