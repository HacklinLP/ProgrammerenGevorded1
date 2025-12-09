namespace AdresLINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            AdresInfo ai = new AdresInfo(@"C:\Users\Lucas Petit\Documents\HoGent\Programmeren Gevorderd 1\AdresLINQ\adresInfo.txt");
            ai.readData();

            foreach (string p in ai.getProvincies()) {
                Console.WriteLine($"Provincie : {p}");
            }

            foreach (string s in ai.getProvincies())
            {
                Console.WriteLine($"Straatnaa, : {s}");
            }
        }
    }
}
