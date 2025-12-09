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
        private IFileReader fileReader;

        public LegoBeheerder(ILegoRepository legoRepository, IFileReader fileReader)
        {
            this.legoRepository = legoRepository;
            this.fileReader = fileReader;
        }

        public void UploadNaarDatabank(string path)
        {
            var data = fileReader.ReadFile(path);

            legoRepository.WriteLegoThemes(data);
        }
    }
}
