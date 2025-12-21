using StadontwikkelingGentBL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Interfaces
{
    public interface IPartnerRepository
    {
        public void MaakPartnerAan(Partner partner);
        public void UpdatePartner(Partner partner);
        public void VerwijderPartner(Partner partner);
        public void VoegPartnerToeAanProject(Project project, Partner partner);
        public List<Partner> GeefPartnerOpNaam(string naam);
        public List<Partner> ZoekOpProjectId(int projectId);
        public bool BestaatEmail(string email);
        List<Partner> GeefAllePartners();
    }
}
