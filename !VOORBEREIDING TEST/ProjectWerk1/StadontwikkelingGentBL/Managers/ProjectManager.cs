using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Managers
{
    public class ProjectManager
    {

        private IReportGenerator _reportGenerator;
        private IProjectRepository _projectRepository;

        public ProjectManager(IReportGenerator reportGent)
        {
            _reportGenerator = reportGent;
            
        }

        public void CreateProject(Project project, int eigenaarId)
        {
            _projectRepository.VoegProjectIn(project, eigenaarId);
        }
        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }
        public void DeleteProject(Project project)
        {
            _projectRepository.VerwijderProject(project);
        }
        public Partner GeefPartnerOpId(int Id)
        {
            return _projectRepository.GeefPartnerOpId(Id);
        }

        public Project GeefProjectOpId(int Id)
        {
            return _projectRepository.GeefProjectOpId(Id);
        }

        public List<Project> ZoekType(string type)
        {
            return _projectRepository.ZoekOpType(type);
            
        }

        public List<Project> ZoekOpWijk(Adres wijk)
        {
            return _projectRepository.ZoekOpWijk(wijk);
        }
        public List<Project> ZoekOpStatus(StatusProject status)
        {
            return _projectRepository.ZoekOpStatus(status);
        }
        public List<Project> ZoekOpPartner(string naam)
        {
            return _projectRepository.ZoekOpPartner(naam);
        }
        public List<Project> ZoekOpStartDatum(DateTime startDatum)
        {
            return _projectRepository.ZoekOpStartDatum(startDatum);
        }


        public void MaakFicheAan(int projectId)
        {
            Project project = _projectRepository.GeefProjectOpId(projectId);
            _reportGenerator.GenerateProjectFiche(project);
        }

        public void VoegFaciliteitToe(Faciliteit faciliteit, int groenId)
        {
            _projectRepository.VoegFaciliteitToe(faciliteit,  groenId);
        }
        public void VerwijderFaciliteit(Faciliteit faciliteit)
        {
            _projectRepository.VerwijderFaciliteit(faciliteit);
        }
        public void UpdateFaciliteit(Faciliteit faciliteit)
        {
            _projectRepository.UpdateFaciliteit(faciliteit);
        }
    }
}
