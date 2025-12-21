using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentDL.Repositories;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DebugConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GebruikerRepository repo = new GebruikerRepository("Data Source=MSI\\MOXXY;Initial Catalog=GentProjectenDatabank;Integrated Security=True;Trust Server Certificate=True");

            ProjectRepository repoPrj = new ProjectRepository("Data Source=MSI\\MOXXY;Initial Catalog=GentProjectenDatabank;Integrated Security=True;Trust Server Certificate=True");



            Console.WriteLine("hello world");


            repo.VoegGebruikerIn(new Gebruiker("Viola", "viola.vanroy@student.hogent.be", "+32477829695", false));











    }
    }
}
