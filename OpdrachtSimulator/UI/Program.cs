using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KlantenSimulatorDL;
using KlantenSimulatorBL.Beheer;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        DataBeheerder dataBeheerder = new DataBeheerder(new BestandsLezer(),
            new BestandsSchrijver(),
            10, 100, 1000, 100000,
            @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\mannennamen_belgie.csv",
            @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\vrouwennamen_belgie.csv",
            @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\Familienamen_2024_Belgie.csv",
            20, 300,
            @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\adresInfo.txt",
            @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\zipcodes_alpha_nl_2025.csv",
            10000
            );


        dataBeheerder.SimuleerPersonen(50, @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\simulator.txt");



        //BestandsLezer bl = new BestandsLezer();

        //var voornaamMannen = bl.LeesNamen(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\mannennamen_belgie.csv");
        //var voornaamVrouwen = bl.LeesNamen(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\vrouwennamen_belgie.csv");
        //var familieNamen = bl.LeesNamen(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\Familienamen_2024_Belgie.csv");
        //var postcodeGemeente = bl.LeesPostcodeGemeente(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\zipcodes_alpha_nl_2025.csv");
        //var straten = bl.LeesNamen(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\adresInfo.txt");


        //AdresSimulator adresSimulator = new AdresSimulator(straten, postcodeGemeente, 300, 20);

        //var a = adresSimulator.GeefAdressen(500);

        //voornaamVrouwen.AddRange(voornaamMannen);

        //PersoonSimulator persoonSimulator = new PersoonSimulator(voornaamVrouwen, familieNamen, a, 10, 100, 10000, 100000000);

        //var p = persoonSimulator.MaakPersoon(25);

        //foreach (var o in p)
        //    Console.WriteLine(o.ToString());

        //BestandsSchrijver bs = new BestandsSchrijver();

        //bs.SchrijfBestand(p, @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\OpdrachtSimulator\simulator.txt");

        //Console.WriteLine("end");
    }
}

