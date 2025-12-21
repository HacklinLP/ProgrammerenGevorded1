using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkDL.Model;

namespace VakantieparkDL.TO
{
    public class WooneenheidTO
    {
        public WooneenheidTO(int? id, string adres, int capaciteit, HuisStatus status, int vakantieparkId)
        {
            Id = id;
            Adres = adres;
            Capaciteit = capaciteit;
            Status = status;
            VakantieparkId = vakantieparkId;
        }

        public int? Id { get; set; }
        public string Adres { get; set; }
        public int Capaciteit { get; set; }
        public HuisStatus Status { get; set; }
        public int VakantieparkId {  get; set; }
    }
}
