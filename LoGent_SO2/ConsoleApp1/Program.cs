using Logent.Domein;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Persoon persoon1 = new Volwassene("Jan", new DateTime(1980, 5, 12), "jan.jpg", new List<Huisdier>(), new Adres("Pastorijstraat", 62, 9000, "Gent"));
        }
    }
}
