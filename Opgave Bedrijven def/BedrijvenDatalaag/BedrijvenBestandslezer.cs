using BedrijvenDomein;

namespace BedrijvenDatalaag
{
    public class BedrijvenBestandslezer
    {

        // StreamReader reader = new StreamReader(pad);

        public List<Bedrijf> LeesBestand(string pad)
        {
            Dictionary<string, Bedrijf> data = new(); // sleutel is hier de bedrijfsnaam (string)

            using(StreamReader reader = new StreamReader(pad))
            {
                string line;
                while ((line = reader.ReadLine()) != null) //We gaan iedere keer een lijn lezen en zolang ze niet null is gaan we verder
                {
                    string[] ss = line.Split('|'); //Dit gebruiken we op een splitsing symbool te creëeren na iedere string
                                                    //SS staat voor substring

                    // Hier geven we iedere index een naam zodat dit heel gemakkelijk terug te vinden is bij welke index welke gegevens horen
                    // Dit zorgt er dan ook voor dat er gemakkelijk en overzichtelijk veranderingen kunnen gebeuren in de code (bv als er index bijkomt)
                    string b_naam = ss[0];
                    string b_industrie = ss[1];
                    string b_sector = ss[2];
                    string b_hoofdkwartier = ss[3];
                    int b_jaar=int.Parse(ss[4]);
                    string b_extra = ss[5];
                    int p_id = int.Parse(ss[6]);
                    string p_voornaam=ss[7];
                    string p_achternaam=ss[8];
                    DateTime p_geboortedatum = DateTime.Parse(ss[9]);
                    string a_gemeente=ss[10];
                    int a_postcode = int.Parse(ss[11]);
                    string a_straat=ss[12];
                    string a_hsnr=ss[13];
                    string p_email=ss[14];

                    //Check of bedrijf al bestaat
                    if (data.ContainsKey(ss[b_naam]))
                    {
                        //maak adres
                        Adres adres = new Adres(a_gemeente, a_straat, a_hsnr, a_postcode);
                        //maak personeel
                        data[b_naam].Personeel.Add(personeel);
                        //voeg personeel toe
                    }
                    else
                    {
                        //maak adres
                        Adres adres = new Adres(a_gemeente, a_straat, a_hsnr, a_postcode);
                        //maak personeel
                        Personeel personeel=new Personeel(p_id, p_voornaam, p_achternaam, p_email, p_geboortedatum, adres);
                        //maak bedrijf
                        Bedrijf bedrijf = new Bedrijf(b_naam, b_industrie, b_extra, b_hoofdkwartier, b_jaar, new List<Personeel>()
                        {
                            personeel
                        });

                        data.Add(b_naam, bedrijf);
                        //voeg personeel toe
                    }
                    //Bedrijf bestaat

                    //Bedrijf bestaat nog niet


                }
            }
            return data.Values.ToList();
        }
    }
}
