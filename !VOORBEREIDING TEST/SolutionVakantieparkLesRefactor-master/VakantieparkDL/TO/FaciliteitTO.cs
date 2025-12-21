using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieparkDL.TO
{
    public class FaciliteitTO
    {
        public FaciliteitTO(int? id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
    }
}
