using StadontwikkelingGentBL.Interfaces;
using StadontwikkelingGentDL.Repositories;

namespace Utils
{
    public class RepositoryFactory
    {
        public IProjectRepository GeefProjectRepository(string connectionString)
        {
            return new ProjectRepository(connectionString);
        }

        public IGebruikerRepository GeefGebruikerRepository(string connectionString)
        {
            return new GebruikerRepository(connectionString);
        }
        
        public IPartnerRepository GeefPartnerRepository(string connectionString)
        {
            return new PartnerRepository(connectionString);
        }

        public IReportGenerator GeefReportGenerator()
        {
            return new ReportGenerator();
        }
    }
}
