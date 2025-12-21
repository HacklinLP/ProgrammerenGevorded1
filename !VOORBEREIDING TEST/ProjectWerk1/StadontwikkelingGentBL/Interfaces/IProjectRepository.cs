using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Interfaces
{
    public interface IProjectRepository
    {
        public void VoegProjectIn(Project project, int eigenaarId);
        public void UpdateProject(Project project);
        public void VerwijderProject(Project project);
        public Partner GeefPartnerOpId(int id);
        public Project GeefProjectOpId(int id);
        public List<Project> ZoekOpType(string type);
        public List<Project> ZoekOpWijk(Adres wijk);
        public List<Project> ZoekOpStatus(StatusProject status);
        public List<Project> ZoekOpPartner(string naam);
        public List<Project> ZoekOpStartDatum(DateTime startDatum);
        public void VerwijderFaciliteit(Faciliteit faciliteit);
        public void UpdateFaciliteit(Faciliteit faciliteit);
        List<ProjectDTOUi> GeefAlleProjecten();
        public void MaakFaciliteitAan(Faciliteit faciliteit);
        public void MaakWoonvormAan(Woonvorm woonvorm);
        public void VoegFaciliteitToe(Faciliteit faciliteit, int groenId);
        public void VoegWoonvormToe(Woonvorm woonvorm, int inoID);
    }
}
