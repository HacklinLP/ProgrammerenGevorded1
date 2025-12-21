using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieparkBL.DTOs;
using VakantieparkBL.Model;

using VakantieparkDL.DAOs;
using VakantieparkDL.TO;

namespace VakantieparkBL.Services
{
    public class VakantieparkService
    {
        private VakantieparkDAO vakantieparkDAO;
        private ContactpersoonDAO contactpersoonDAO;
        private FaciliteitDAO faciliteitDAO;
        private WooneenheidDAO wooneenheidDAO;

        public VakantieparkService()
        {
            vakantieparkDAO=new VakantieparkDAO();
            contactpersoonDAO=new ContactpersoonDAO();
            faciliteitDAO = new FaciliteitDAO();
            wooneenheidDAO=new WooneenheidDAO();
        }

        public List<VakantieparkDTO> GeefVakantieparken()
        {
            List<VakantieparkDTO> data = new();
            foreach (VakantieparkTO v in vakantieparkDAO.GeefVakantieparken())
            {
                data.Add(new VakantieparkDTO((int)v.Id,v.Naam,v.Locatie,
                    wooneenheidDAO.GeefCapaciteitVoorVakantiepark((int)v.Id),
                    wooneenheidDAO.GeefAantalWooneenhedenVoorVakantiepark((int)v.Id),
                    faciliteitDAO.GeefAantalFaciliteitenVoorVakantiepark((int)v.Id),
                    contactpersoonDAO.GeefContactpersoon(v.ContactpersoonID).Email));
            }
            return data;
        }
        public Vakantiepark GeefVakantiepark(int id)
        {
            var v = vakantieparkDAO.GeefVakantiepark(id);
            var c = contactpersoonDAO.GeefContactpersoon(v.ContactpersoonID);
            var f = faciliteitDAO.GeefFaciliteitenVoorVakantiepark(id);
            var w = wooneenheidDAO.GeefWooneenhedenVoorVakantiepark(id);
            return new Vakantiepark(v.Id,v.Naam,v.Locatie,
                new Contactpersoon(c.Id,c.Naam,c.Email,c.Telefoon),
                f.Select(x=>new Faciliteit(x.Id,x.Naam)).ToList(),
                w.Select(x=>new Wooneenheid(x.Id,x.Adres,x.Capaciteit,x.Status)).ToList());
        }
    }
}
