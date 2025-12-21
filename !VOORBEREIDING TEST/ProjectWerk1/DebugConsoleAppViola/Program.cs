using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentDL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DebugConsoleAppViola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProjectRepository projectRepo = new ProjectRepository("Data Source=LAPTOP-EFC7U6RT\\SQLEXPRESS;Initial Catalog=GentProjectenDatabank;Integrated Security=True;Trust Server Certificate=True");

            Adres adres = new("bla", "bla", "blabla", "blabla bu", "buba");
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
            Project project = new("Test", DateTime.Now, StatusProject.Planning, "coole beschrijving ofzo", adres, partners, projects);
            projectRepo.GeefProjectOpId(3);
            Project project1 = projectRepo.GeefProjectOpId(3);
            Console.WriteLine("Hello world!");
        }
    }
}
