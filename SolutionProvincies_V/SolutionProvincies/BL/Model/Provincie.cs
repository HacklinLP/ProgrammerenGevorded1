using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Exceptions;

namespace BL.Model {
    public class Provincie {
        public Provincie(string naam, List<Gemeente> gemeentes) {
            Naam = naam;
            if (gemeentes == null || gemeentes.Count == 0) throw new ProvincieException("gemeentes niet ok");
            foreach (var g in gemeentes) AddGemeente(g);
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
        private List<Gemeente> _gemeentes = new();
        public IReadOnlyList<Gemeente> Gemeentes => _gemeentes;
        public void AddGemeente(Gemeente gemeente) {
            if (gemeente == null) throw new ProvincieException("gemeente is null");
            _gemeentes.Add(gemeente);
        }
    }
}
