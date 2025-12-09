using LegoBL.Beheer;
using Microsoft.Extensions.Configuration;

namespace Test_Lego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Lego;Integrated Security=True;Trust Server Certificate=True";
            string pad = @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\Test_Lego (verbetering)\files\lego_sets.csv";

            LegoBeheerder manager = new LegoBeheerder(new FileReader(), new LegoRepository(connectionString));
            manager.DBUpload(pad);

            

            // config van json werkt


        }
    }
}
