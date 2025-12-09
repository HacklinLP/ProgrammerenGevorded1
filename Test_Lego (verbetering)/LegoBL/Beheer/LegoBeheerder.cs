using LegoBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBL.Beheer
{
    public class LegoBeheerder
    {
        private ILegoRepository legoRepository;
        private IFileReader reader;

        public LegoBeheerder(ILegoRepository legoRepository, IFileReader reader)
        {
            this.legoRepository = legoRepository;
            this.reader = reader;
        }

        public void DBUpload(string path)
        {
            var data = reader.ReadFile(path);

            legoRepository.WriteLegoThemes(data);
        }
    }
}
