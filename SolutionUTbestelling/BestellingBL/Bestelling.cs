using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestellingBL
{
    public class Bestelling
    {
        private Dictionary<Product, int> producten = new();
        public Bestelling(DateTime bestelDatum)
        {
            BestelDatum = bestelDatum;
        }

        public int Id { get; set; }

        private DateTime bestelDatum;

        public DateTime BestelDatum
        {
            get { return bestelDatum; }
            set
            {
                if (value == default || value >= LeverDatum)
                    throw new BestellingException("besteldatum");
                bestelDatum = value;
            }
        }
        private DateTime? leverDatum;
        public DateTime? LeverDatum
        {
            get
            {
                return leverDatum;
            }
            set
            {
                if (value != DateTime.MinValue && value <= BestelDatum)
                {
                    throw new BestellingException("leverdatum");
                }
                leverDatum = value; 
            }
        }
        public void VoegProductToe(Product product, int aantal)
        {
            if (aantal <= 0 || product == null)
                throw new BestellingException("voeg product toe");
            if (producten.ContainsKey(product))
            {
                producten[product] += aantal;
            }
            else
                producten.Add(product, aantal);
        }
        public void VerwijderProduct(Product product, int aantal)
        {
            if (aantal <= 0 || product == null)
                throw new BestellingException("verwijder product");
            if (producten.ContainsKey(product))
            {
                throw new BestellingException("verwijder product");
            }
            if (producten[product] > aantal)
                producten[product] -= aantal;
            else if (producten[product] == aantal)
                producten.Remove(product);
            else throw new BestellingException("verwijder product");
        }
        public double Prijs()
        {
            throw new NotImplementedException();
                
        }
        public IReadOnlyList<(Product, int)> Producten()
        {
            return producten.Select(kvp => (kvp.Key, kvp.Value)).ToList();
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                id == product.Id &&
                naam == product.Naam &&
                Prijs == product.Prijs;
        }
    }
}
