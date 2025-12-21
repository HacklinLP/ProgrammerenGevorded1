using Cui;
using Domein;
using Persistentie;

namespace Main
{
	
	public class StartUp
	{
		public static void Main(string[] args)
		{
			(new StartUp()).Run();
		}
		private void Run()
		{
			IAutoRepository autoRepo = new AutoRepository();
			IOnderhoudRepository onderhoudRepo = new OnderhoudRepository();
			GarageDBApp app = new GarageDBApp(new DomeinController(autoRepo, onderhoudRepo));

			app.BewerkDB();
		}
	}

}