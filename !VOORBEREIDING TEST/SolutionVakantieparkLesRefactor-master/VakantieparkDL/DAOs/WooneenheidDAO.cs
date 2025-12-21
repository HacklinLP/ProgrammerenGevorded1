using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkDL.Model;
using VakantieparkDL.TO;

namespace VakantieparkDL.DAOs
{
    public class WooneenheidDAO
    {
        private int wooneenhedenId = 1;
        private Dictionary<int, WooneenheidTO> wooneenheden = new();

        public WooneenheidDAO()
        {
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "hoofdstraat 1", 5, HuisStatus.Beschikbaar,1)); wooneenhedenId++;
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "hoofdstraat 71", 3, HuisStatus.Beschikbaar, 1)); wooneenhedenId++;
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "hoofdstraat 11", 15, HuisStatus.Beschikbaar, 1)); wooneenhedenId++;
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "speelstraat 1", 5, HuisStatus.Beschikbaar,2)); wooneenhedenId++;
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "speelstraat 11", 2, HuisStatus.Beschikbaar,2)); wooneenhedenId++;
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "speelstraat 15", 7, HuisStatus.Beschikbaar,2)); wooneenhedenId++;
            wooneenheden.Add(wooneenhedenId, new WooneenheidTO(wooneenhedenId, "speelstraat 17", 9, HuisStatus.Beschikbaar,1)); wooneenhedenId++;
        }

        public List<WooneenheidTO> GeefWooneenhedenVoorVakantiepark(int id)
        {
            return wooneenheden.Values.Where(x=>x.VakantieparkId==id).ToList();
        }
        public int GeefCapaciteitVoorVakantiepark(int id)
        {
            return wooneenheden.Values.Where(x => x.VakantieparkId == id).Sum(x => x.Capaciteit);
        }
        public int GeefAantalWooneenhedenVoorVakantiepark(int id)
        {
            return wooneenheden.Values.Where(x => x.VakantieparkId == id).Count();
        }
    }
}
