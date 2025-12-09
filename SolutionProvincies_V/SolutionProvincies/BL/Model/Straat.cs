using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model {
    public class Straat 
    {
        public Straat(string naam) 
        {
            Naam = naam;
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
    }
}
