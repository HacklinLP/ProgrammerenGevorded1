using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDL_File.Model
{
    internal class LegoSetDL
    {
        public string Naam {  get; set; }
        public LegoSetDL(string naam)
        {
            Naam = naam;
        }
    }
}
