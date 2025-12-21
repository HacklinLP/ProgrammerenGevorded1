using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkBL.Exceptions;

namespace VakantieparkBL.Model
{
    public class Vakantiepark
    {
        public int? Id { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public Contactpersoon Contactpersoon { get; set; }
        private List<Faciliteit> faciliteiten;
        private List<Wooneenheid> wooneenheden;

        public Vakantiepark(int? id, string naam, string locatie, Contactpersoon contactpersoon, List<Faciliteit> faciliteiten, List<Wooneenheid> wooneenheden)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
            Contactpersoon = contactpersoon;
            this.faciliteiten = faciliteiten;
            this.wooneenheden = wooneenheden;
        }

        public IReadOnlyList<Faciliteit> Faciliteiten => faciliteiten;
        public IReadOnlyList<Wooneenheid> Wooneenheden => wooneenheden;
        public void VoegFaciliteitToe(Faciliteit faciliteit)
        {
            if (faciliteit == null) throw new VakantieparkException("VoegFaciliteitToe");
            if (faciliteiten.Contains(faciliteit)) throw new VakantieparkException("VoegFaciliteitToe");
            faciliteiten.Add(faciliteit);
        }
        public void VerwijderFaciliteit(Faciliteit faciliteit)
        {
            if (faciliteit == null) throw new VakantieparkException("VerwijderFaciliteit");
            if (!faciliteiten.Contains(faciliteit)) throw new VakantieparkException("VerwijderFaciliteit");
            faciliteiten.Remove(faciliteit);
        }
        public void VoegWooneenheidToe(Wooneenheid wooneenheid)
        {
            if (wooneenheid == null) throw new VakantieparkException("VoegWooneenheidToe");
            if (wooneenheden.Contains(wooneenheid)) throw new VakantieparkException("VoegWooneenheidToe");
            wooneenheden.Add(wooneenheid);
        }
        public void VerwijderWooneenheid(Wooneenheid wooneenheid)
        {
            if (wooneenheid == null) throw new VakantieparkException("VerwijderWooneenheid");
            if (!wooneenheden.Contains(wooneenheid)) throw new VakantieparkException("VerwijderWooneenheid");
            wooneenheden.Remove(wooneenheid);
        }
        public int Capaciteit()=>wooneenheden.Where(x=>x.Status==HuisStatus.Beschikbaar).Sum(x=>x.Capaciteit);
        public int MaxCapaciteit() => wooneenheden.Sum(x => x.Capaciteit);
    }
}
