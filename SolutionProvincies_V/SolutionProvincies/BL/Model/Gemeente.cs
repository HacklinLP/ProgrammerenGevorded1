using BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model 
{
    public class Gemeente 
    {
        public Gemeente(string naam, List<Straat> straten) 
        {
            Naam = naam;
            if (straten == null || straten.Count == 0) throw new ProvincieException("gemeentes niet ok");
            foreach (var s in straten) AddStraat(s);
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
        private List<Straat> _straten = new();
        public IReadOnlyList<Straat> Straten => _straten;
        public void AddStraat(Straat straat) 
        {
            if (straat == null) throw new ProvincieException("straat is null");
            _straten.Add(straat);
        }
    }
}
