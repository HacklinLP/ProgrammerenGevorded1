using System;

namespace Domein
{
	public abstract class Onderhoud
	{
		public Onderhoud(DateTime begindatum, DateTime einddatum, string nummerplaat)
		{
			BeginDatum = begindatum;
			EindDatum = einddatum;
			Nummerplaat = nummerplaat;
		}

		public DateTime BeginDatum { get; set; }

		public DateTime EindDatum { get; set; }

		public string Nummerplaat { get; set; }

		public override string ToString()
		{
			return string.Format("nummerplaat {0} van {1} t.e.m. {2}", Nummerplaat, BeginDatum.ToShortDateString(), EindDatum.Date.ToShortDateString());
		}

		public static int VergelijkOpNummerplaatDanOpBeginDatum(Onderhoud o1, Onderhoud o2)
        {
			int result = o1.Nummerplaat.CompareTo(o2.Nummerplaat);

			if (result != 0)
            {
				return result;
            }

			return o1.BeginDatum.CompareTo(o2.BeginDatum);
        }

	}

}