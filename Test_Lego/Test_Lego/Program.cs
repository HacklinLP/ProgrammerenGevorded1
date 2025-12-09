using Microsoft.Extensions.Configuration;

namespace Test_Lego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            string connectionString = config.GetConnectionString("SQLserver");
            string pad = config.GetSection("AppSettings")["legoSetsInfo"];
            int aantal = int.Parse(config.GetSection("AppSettings")["aantal"]);

            // config van json werkt


        }
    }
}
