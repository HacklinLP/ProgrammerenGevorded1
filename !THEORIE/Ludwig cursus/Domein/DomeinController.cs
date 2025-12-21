using System;
using System.Collections.Generic;
using System.Linq;

namespace Domein
{

	public class DomeinController
	{
		private Garage _garage;
		public DomeinController(IAutoRepository autoRepo, IOnderhoudRepository onderhoudRepo)
		{
			_garage = new Garage(autoRepo, onderhoudRepo);
		}
		
		public void RegistreerAuto(string nummerplaat, string merk, string model )
		{
			_garage.RegistreerAuto(nummerplaat, merk, model);
		}

		public List<String> GeefAutos()
        {
			return _garage.GeefAutos()
				.Select(auto => auto.ToString())
				.ToList();
        }

		public string GeefAuto(string nummerplaat)
		{
			return _garage.GeefAuto(nummerplaat).ToString();
		}

		public void WijzigAuto(string nummerplaat, string merk, string model)
		{
			_garage.WijzigAuto(nummerplaat, merk, model);
		}

		public void VerwijderAuto(string nummerplaat)
		{
			_garage.VerwijderAuto(nummerplaat);
		}
	}
}