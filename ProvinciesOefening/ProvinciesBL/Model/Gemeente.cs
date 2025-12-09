using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvinciesBL.Model
{
    public class Gemeente
    {
        public int? Id { get; set; }
        public string Naam { get; set; }

        public Gemeente(string naam)
        {
            Naam = naam;
        }

        
    }
}
