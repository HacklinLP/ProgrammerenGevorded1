using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public interface IAutoRepository
    {
        List<Auto> GeefAutos();
        Auto ReadAuto(string nummerplaat);
        void InsertAuto(Auto auto);
        void DeleteAuto(string nummerplaat);
        void UpdateAuto(Auto auto);
    }
}
