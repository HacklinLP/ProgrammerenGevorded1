// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var config = builder.Build();


string connectionString=config.GetConnectionString("SQLConnection");
string pad=config.GetSection("AppSettings")["bestandAdresinfo"];
int aantal=int.Parse(config.GetSection("AppSettings")["aantal"]);

Console.WriteLine(connectionString);
Console.WriteLine(pad);
Console.WriteLine(aantal);

