using System;

namespace Domein
{

	public class Auto
	{
		public Auto(string nummerplaat, string merk, string model)
		{
			Nummerplaat = nummerplaat;
			Merk = merk;
			Model = model;
		}

		public string Merk { get; set; }

		public string Model { get; set; }

		public string Nummerplaat { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Auto auto &&
                   Nummerplaat == auto.Nummerplaat;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nummerplaat);
        }

        public override string ToString()
		{
			return string.Format("nummerplaat= {0}, merk= {1}, model = {2}", Nummerplaat, Merk, Model);
		}

		
	}

}