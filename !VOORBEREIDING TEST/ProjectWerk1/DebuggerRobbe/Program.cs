using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentDL.Repositories;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DebuggerRobbe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GebruikerRepository repo = new GebruikerRepository("Data Source = LOBSTERCENTRAL\\SQLEXPRESS; Initial Catalog = GentProjectenDatabank; Integrated Security = True; Trust Server Certificate = True");


            //Gebruiker meeee = new Gebruiker("VD", "email@email.be", "+32477829695", true);

            //if (!repo.BestaatEmail(meeee.Email)) { repo.VoegGebruikerIn(meeee); }

            ProjectRepository repository = new("Data Source = LOBSTERCENTRAL\\SQLEXPRESS; Initial Catalog = GentProjectenDatabank; Integrated Security = True; Trust Server Certificate = True");

            /*Adres adres = new("bla", "bla", "blabla", "blabla bu", "buba");
            List<string> strings = new();
            strings.Add("bla");
            strings.Add("buh");

            Bedrijf Bedrijf = new("naam", "email@email.be", "02939201", "Bedrijf", strings);
            List<Partner> partners = new();
            partners.Add(Bedrijf);

            Faciliteit faciliteit = new("bla", true);
            List<Faciliteit> faciliteits = new();
            faciliteits.Add(faciliteit);

            GroeneRuimteProject grpr = new(12.4, 4, 6, faciliteits, true, 2);
            Woonvorm woonvorm = new("bla", false);
            List<Woonvorm> woonvorms = new();
            woonvorms.Add(woonvorm);

            InnovatiefWonenProject ivpr = new(1, woonvorms, true, true, 4, true);

            StadsOntwikkelingsProject stpr = new(VergunningStatus.Geweigerd, true, OpenbareToegankelijkheid.Gedeeltelijk, true, true);
            List<TypeProject> projects = new();
            projects.Add(stpr);
            projects.Add(grpr);
            projects.Add(ivpr);
            Project project = new("Blatest", DateTime.Now, StatusProject.Planning, "coole beschrijving enzo", adres, partners, projects);
            repository.VoegProjectIn(project, 1);*/

            PartnerRepository partnerRepository = new("Data Source = LOBSTERCENTRAL\\SQLEXPRESS; Initial Catalog = GentProjectenDatabank; Integrated Security = True; Trust Server Certificate = True");
            List<string> rollen = new();
            rollen.Add("games");
            rollen.Add("Tech");
            Bedrijf bedrijf = new Bedrijf("Nintendo", "nintendo@gmail.com", "04708065", "Epicsauce", rollen);
            Bouwfirma bouwfirma = new Bouwfirma("MarioBuilders", "Builders@gmail.com", "04756070", "SauceEpic", rollen);
            partnerRepository.MaakPartnerAan(bedrijf);
            partnerRepository.MaakPartnerAan(bouwfirma);
        }




        
    }
}

