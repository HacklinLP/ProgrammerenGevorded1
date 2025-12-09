using BL.Interfaces;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Beheer {
    public class ProvincieBeheerder 
    {
        private IProvincieRepository _repo;
        private IProvincieBestandLezer _bestandlezer;

        public ProvincieBeheerder(IProvincieRepository repo, IProvincieBestandLezer bestandlezer) {
            _repo = repo;
            _bestandlezer = bestandlezer;
        }


        public void ClearFolder(string folderName)
        {
            _bestandlezer.CleanFolder();
        }
        public List<string> GeefInhoudZip(string fileName)
        {
            return _bestandlezer.GeefInhoudZip(fileName);

        }

        public bool IsFolderEmpty(string folderName)
        {
            DirectoryInfo di = new DirectoryInfo(folderName);
            return (di.GetFiles().Length == 0 && di.GetDirectories().Length == 0);
        }

        public void UnZip(string zipFile, string outputFolder)
        {
            _bestandlezer.Unzip(zipFile, outputFolder);
        }

        public void UploadNaarDatabank(string folder, List<string> bestandsnamen)
        {
            // stap 1 lezen bestanden
            var data = _bestandlezer.LeesBestanden(folder, bestandsnamen);
            Statistieken stats = new Statistieken(data);

            // stap 2 schrijven naar databank
            _repo.UploadToDatabase(data);
        }
    }
}
