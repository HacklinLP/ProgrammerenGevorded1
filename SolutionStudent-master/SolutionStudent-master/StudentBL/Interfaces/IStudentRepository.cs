using StudentBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL.Interfaces
{
    public interface IStudentRepository
    {
        List<Cursus> GeefCursussen(string voorwaarde);
        Student GeefStudent(int id);
        bool HeeftStudent(string naam);
        void VoegCursussenToe(List<Cursus> cursussen);
        void VoegKlasToe(Klas klas);
        void VoegStudentToe(Student student);
    }
}
