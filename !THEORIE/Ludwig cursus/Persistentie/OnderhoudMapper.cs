using Domein;
using System;
using System.Collections.Generic;

namespace Persistentie
{
	public class OnderhoudMapper
	{
		public List<Onderhoud> GeefOnderhoudVanAutos()
		{
			List<Onderhoud> onderhoudLijst = new List<Onderhoud>();
			
			DateTime begindatum = new DateTime(2019, 12, 12);
			DateTime einddatum = new DateTime(2019, 12, 15);
			Onderhoud onderhoud = new OnderhoudGroot(begindatum, einddatum, "xy12xy");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 1, 11);
			einddatum = new DateTime(2020, 1, 11);
			onderhoud = new OnderhoudKlein(begindatum, "ab12ab");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 12, 15);
			einddatum = new DateTime(2020, 12, 15);
			onderhoud = new OnderhoudKlein(begindatum, "ab12ab");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 1, 11);
			einddatum = new DateTime(2020, 1, 12);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "789cde");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 11, 16);
			einddatum = new DateTime(2019, 11, 16);
			onderhoud = new OnderhoudKlein(begindatum, "xy12xy");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 1, 15);
			einddatum = new DateTime(2020, 1, 15);
			onderhoud = new OnderhoudKlein(begindatum, "ab12ab");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 17);
			einddatum = new DateTime(2019, 12, 19);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "456abc");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 1, 10);
			einddatum = new DateTime(2020, 1, 10);
			onderhoud = new OnderhoudKlein(begindatum, "789cde");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 8);
			einddatum = new DateTime(2019, 12, 8);
			onderhoud = new OnderhoudKlein(begindatum, "xy12xy");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 1, 17);
			einddatum = new DateTime(2020, 1, 17);
			onderhoud = new OnderhoudKlein(begindatum, "ab12ab");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 10);
			einddatum = new DateTime(2019, 12, 11);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "123xyz");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 15);
			einddatum = new DateTime(2019, 12, 16);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "123xyz");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 15);
			einddatum = new DateTime(2019, 12, 16);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "azerty");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 2, 15);
			einddatum = new DateTime(2020, 2, 15);
			onderhoud = new OnderhoudKlein(begindatum, "567xyz");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2020, 1, 5);
			einddatum = new DateTime(2020, 1, 7);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "789cde");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 17);
			einddatum = new DateTime(2019, 12, 19);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "123xyz");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 18);
			einddatum = new DateTime(2019, 12, 18);
			onderhoud = new OnderhoudKlein(begindatum, "azerty");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 17);
			einddatum = new DateTime(2019, 12, 17);
			onderhoud = new OnderhoudKlein(begindatum, "azerty");
			onderhoudLijst.Add(onderhoud);

			begindatum = new DateTime(2019, 12, 20);
			einddatum = new DateTime(2019, 12, 22);
			onderhoud = new OnderhoudGroot(begindatum, einddatum, "azerty");
			onderhoudLijst.Add(onderhoud);

			return onderhoudLijst;
		}
	}

}