using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Beheer {
    public class ProvincieBeheerder {
        private IProvincieRepository repo;
        private IProvincieBestandLezer bestandlezer;

        public ProvincieBeheerder(IProvincieRepository repo, IProvincieBestandLezer bestandlezer) {
            this.repo = repo;
            this.bestandlezer = bestandlezer;
        }

        public void UploadNaarDatabank(string folder, List<string> bestandsnamen)
        {
            // stap 1 lezen bestanden
            var data = bestandlezer.LeesBestanden(folder, bestandsnamen);

            // stap 2 schrijven naar databank
            repo.UploadToDatabase(data);
        }
    }
}
