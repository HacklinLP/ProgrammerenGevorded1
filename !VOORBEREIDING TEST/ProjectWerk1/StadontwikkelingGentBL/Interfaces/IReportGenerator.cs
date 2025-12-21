using StadontwikkelingGentBL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Interfaces
{
    public interface IReportGenerator
    {
        public void GenerateProjectFiche(Project project);
        public void ExportToCsv(Project project);
        public void ExportToPdf(Project project);
    }
}
