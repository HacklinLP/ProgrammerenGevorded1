using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentDL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DebugConsoleAppBradley
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Gebruiker Bradley = new Gebruiker("Bradley", "dhaenebradley@outlook.com", "+32468024725", true);
            Gebruiker BradleyFake = new Gebruiker("Bradley", "bradleydhaene@outlook.com", "+32468024725", false);

            GebruikerRepository gebruikerRepo = new GebruikerRepository("Data Source = BRADLEY\\SQLEXPRESS; Initial Catalog = GentProjectenDatabank; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
            //gebruikerRepo.VoegGebruikerIn(Bradley);
            gebruikerRepo.VoegGebruikerIn(BradleyFake);
        }
    }
}
