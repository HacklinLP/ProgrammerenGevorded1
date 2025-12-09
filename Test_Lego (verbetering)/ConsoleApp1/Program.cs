using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            FileReader fr = new FileReader();
            string pad = @"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\Test_Lego (verbetering)\files\lego_sets.csv";
            var data = fr.ReadFile(pad);
            var q1 = data.OrderByDescending(x => x.LegoSets.Count()).Select(x => x.LegoSets);
            Console.WriteLine("end");
        }
    }
}
