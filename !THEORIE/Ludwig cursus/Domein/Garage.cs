using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domein
{
	public class Garage
	{
		private IAutoRepository _autoRepo;
		private IOnderhoudRepository _onderhoudRepo;

		public Garage(IAutoRepository autoRepo, IOnderhoudRepository onderhoudRepo)
		{
			_autoRepo = autoRepo;
			_onderhoudRepo = onderhoudRepo;
		}

		public void RegistreerAuto(string nummerplaat, string merk, string model )
        {
			_autoRepo.InsertAuto(new Auto(nummerplaat, merk, model));
        }

		public List<Auto> GeefAutos()
        {
			return _autoRepo.GeefAutos();
        }

		public Auto GeefAuto(string nummerplaat)
        {
			return _autoRepo.ReadAuto(nummerplaat);
        }

		public void WijzigAuto(string nummerplaat, string merk, string model )
        {
			_autoRepo.UpdateAuto(new Auto(nummerplaat, merk, model));
        }

        public void VerwijderAuto(string nummerplaat)
		{
			_autoRepo.DeleteAuto(nummerplaat);
		}
	}
}