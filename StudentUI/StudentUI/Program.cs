using Microsoft.Extensions.Configuration;
using StudentBL.Beheerders;
using StudentBL.Interfaces;
using StudentBL.Model;
using StudentUtils;

namespace StudentUI
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

            Student student = new Student("Juul");
            // IStudentRepository repo = new StudentRepository(connectionString);
            StudentBeheerder studentBeheerder = new StudentBeheerder(RepoFactory.GeefRepo(connectionString));
            //Klas klas = new Klas("1F");
            //klas.Lokaal = "C2.051";
            //studentBeheerder.VoegStudentToe(student);
            //studentBeheerder.VoegKlasToe(klas);

            //List<Cursus> cursussen = new List<Cursus>();
            //cursussen.Add(new Cursus("PG1"));
            //cursussen.Add(new Cursus("Softwareontwerp 2"));
            //studentBeheerder.VoegCursussenToe(cursussen);

            //var data = studentBeheerder.GeefCursussen();

            //student.Cursussen = data;
            //student.Klas = new Klas(1, "xxxx");
            //studentBeheerder.VoegStudentToe(student);

            studentBeheerder.GeefStudent(4);
        }
    }
}
