using BL.Beheer;
using Microsoft.Extensions.Configuration;
using ProvinciesUtil.Factories;

namespace UI
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
            string folder = config.GetSection("AppSettings")["folder"];
            List<string> bestandsnamen = new();
            bestandsnamen.Add(config.GetSection("AppSettings")["ProvincieIDsVlaanderen"]);
            bestandsnamen.Add(config.GetSection("AppSettings")["ProvincieInfo"]);
            bestandsnamen.Add(config.GetSection("AppSettings")["Gemeentenaam"]);
            bestandsnamen.Add(config.GetSection("AppSettings")["StraatnaamID_gemeenteID"]);
            bestandsnamen.Add(config.GetSection("AppSettings")["straatnamen"]);


            ProvincieBeheerder provincieBeheerder = new ProvincieBeheerder(ProvincieRepositoryFactory.GeefRepository(connectionString), ProvincieBestandLezerFactory.GeefBestandsLezer());
            provincieBeheerder.UploadNaarDatabank(folder );
        }
    }
}
