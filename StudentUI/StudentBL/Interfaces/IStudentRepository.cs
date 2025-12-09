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
        List<Cursus> GeefCursussen();
        void GeefStudent(int id);
        void VoegCursussenToe(List<Cursus> cursussen);
        void VoegKlasToe(Klas klas);
        void VoegStudentToe(Student student);
    }
}
