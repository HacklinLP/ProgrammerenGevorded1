using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkDL.TO;

namespace VakantieparkDL.DAOs
{
    public class VakantieparkDAO
    {
        private int vakantieparkId = 1;
        private Dictionary<int, VakantieparkTO> vakantieparken = new();

        public VakantieparkDAO()
        {
            vakantieparken.Add(vakantieparkId, new VakantieparkTO(vakantieparkId, "Gentpark", "Gent", 1)); vakantieparkId++;
            vakantieparken.Add(vakantieparkId, new VakantieparkTO(vakantieparkId, "Lokeren meersen", "Lokeren", 2)); vakantieparkId++;
        }

        public VakantieparkTO GeefVakantiepark(int id)
        {
           return vakantieparken[id];
        }
        public List<VakantieparkTO> GeefVakantieparken()
        {
            return vakantieparken.Values.ToList();
        }
    }
}
