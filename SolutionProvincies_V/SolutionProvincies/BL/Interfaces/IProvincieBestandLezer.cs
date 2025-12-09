using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Model;

namespace BL.Interfaces
{
    public interface IProvincieBestandLezer
    {
        List<string> GeefInhoudZip(string fileName);

        // geen dictionary want ID's steken we toch niet in databank
        public List<Provincie> LeesBestanden(string folder, List<string> bestandsNamen);
        public void Unzip(string zipFile, string outputFolder);
    }
}
