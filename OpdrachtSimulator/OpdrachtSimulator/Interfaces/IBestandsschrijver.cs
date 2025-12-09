using KlantenSimulatorBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantenSimulatorBL.Interfaces
{
    public interface IBestandsschrijver
    {
        void SchrijfBestand(List<Persoon> data, string pad);
    }
}
