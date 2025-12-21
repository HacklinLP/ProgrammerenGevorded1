using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Managers
{
    public class PartnerManager
    {
        private IPartnerRepository _partnerRepo;
        public void MaakPartnerAan(Partner partner)
        {
            _partnerRepo.MaakPartnerAan(partner);
        }
        public void VoegPartnerToeAanProject(Project project, Partner partner)
        {
            _partnerRepo.VoegPartnerToeAanProject(project, partner);
        }
        public List<Partner> ZoekOpProjectId(int projectId)
        {
            return _partnerRepo.ZoekOpProjectId(projectId);
        }
    }
}
