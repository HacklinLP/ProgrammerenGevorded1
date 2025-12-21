using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkDL.TO;

namespace VakantieparkDL.DAOs
{
    public class FaciliteitDAO
    {
        private Dictionary<int, FaciliteitTO> faciliteiten = new();
        private Dictionary<int,List<int>> tussentabel = new();
        private int faciliteitenId = 1;

        public FaciliteitDAO()
        {
            faciliteiten.Add(faciliteitenId, new FaciliteitTO(faciliteitenId, "speeltuin")); faciliteitenId++;
            faciliteiten.Add(faciliteitenId, new FaciliteitTO(faciliteitenId, "trampoline")); faciliteitenId++;
            faciliteiten.Add(faciliteitenId, new FaciliteitTO(faciliteitenId, "bowling")); faciliteitenId++;
            faciliteiten.Add(faciliteitenId, new FaciliteitTO(faciliteitenId, "tennis")); faciliteitenId++;
            faciliteiten.Add(faciliteitenId, new FaciliteitTO(faciliteitenId, "zwembad")); faciliteitenId++;
            tussentabel.Add(1,new List<int>() { 1,4,2});
            tussentabel.Add(2,new List<int>() { 3, 5, 2 });
        }

        public List<FaciliteitTO> GeefFaciliteitenVoorVakantiepark(int id)
        {
            return faciliteiten.Values.Where(x=>tussentabel[id].Contains((int)x.Id)).ToList();
        }
        public int GeefAantalFaciliteitenVoorVakantiepark(int id)
        {
            return tussentabel[id].Count;
        }
    }
}
