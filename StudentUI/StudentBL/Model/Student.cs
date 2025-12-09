using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL.Model
{
    public class Student
    {
        public int? Id { get; set; }

        public string Naam { get; set; }

        public Klas Klas { get; set; }

        public List<Cursus> Cursussen { get; set; } = new();

        public Student(string naam)
        {
            Naam = naam;
        }

        public Student(int? id, string naam)
        {
            Id = id;
            Naam = naam;
        }
    }
}
