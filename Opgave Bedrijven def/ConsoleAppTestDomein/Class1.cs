using BedrijvenDatalaag;
using BedrijvenDomein;

BedrijvenBestandslezer bl = new BedrijvenBestandslezer();
var data = bl.LeesBestand(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\Testbestandje.txt");


string gemeente = "Gent";

BedrijvenDataBeheerder db = new BedrijvenDataBeheerder(data);

var res = db.GeefPersoneelBedrijf("UCB");

var resgemeente = db.GeefPersoneelGemeente(gemeente);
foreach(var item in resgemeente) Console.WriteLine(item);



//Adres adres1 = null;
//try
//{
//    adres1 = new Adres("Gent", "Bijloke", "45", 95000);
//}
//catch (BedrijfException ex)
//{
//    Console.WriteLine(ex.Message);
//    foreach (var e in ex.Errors) Console.WriteLine(e);
//}
//Adres adres2 = null;
//try
//{
//    adres2 = new Adres("Gent", "Bijloke", "45", 9500);
//}
//catch (BedrijfException ex)
//{
//    Console.WriteLine(ex.Message);
//}

//Console.WriteLine(adres1);
//Console.WriteLine(adres2);