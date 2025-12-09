using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    public class Statistieken
    {
        private List<Provincie> provincies;

        public Statistieken(List<Provincie> provincies)
        {
            this.provincies = provincies;
            ProvinciesAantalGemeenten = provincies.ToDictionary(x => x.Naam, x => x.Gemeentes.Count());
            GemeentesAantalStraten = provincies.SelectMany(x => x.Gemeentes, (p, g) => new { naam = $"{p.Naam},{g.Naam}", aantal = g.Straten.Count() }).ToDictionary(x => x.naam, x => x.aantal);
        }
        public IReadOnlyDictionary<string, int> Provincies { get; private set; }
        public IReadOnlyDictionary<string, int> Gemeenten { get; private set; }
    }
}
