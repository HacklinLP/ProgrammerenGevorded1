using Microsoft.Extensions.DependencyInjection;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentDL.Repositories
{
    public class ReportGenerator : IReportGenerator
    {
        public void ExportToCsv(Project project)
        {
            string padNaarDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"{project.Titel}-ProjectFiche.csv";
            string padNaamFile = Path.Combine(padNaarDesktop, fileName);
            using (StreamWriter writer = File.CreateText(padNaamFile))
            {
                writer.WriteLine("Project_ID | Titel | StartDatum | Status | Beschrijving | Straat | Huisnummer | Gemeent | Provincie | Wijk ");
                
                List<TypeProject> subprojecten = (List<TypeProject>)project.ProjectTypes;
                GroeneRuimteProject groene = null;
                InnovatiefWonenProject inno = null;
                StadsOntwikkelingsProject stads = null;
                foreach(TypeProject type in subprojecten)
                {
                    if (type.GetType() == typeof(GroeneRuimteProject)) groene = (GroeneRuimteProject)type;
                    else if (type.GetType() == typeof(InnovatiefWonenProject)) inno = (InnovatiefWonenProject)type;
                    else if (type.GetType() == typeof(StadsOntwikkelingsProject)) stads = (StadsOntwikkelingsProject)type;
                }

                string projectInfo = string.Join('|', project.Id.ToString(), project.Titel, project.StartDatum.ToString(), project.Status.ToString(), project.Beschrijving, project.Locatie.Straat
                    , project.Locatie.Huisnummer, project.Locatie.Gemeente, project.Locatie.Provincie, project.Locatie.Wijk);
                writer.WriteLine(projectInfo);
                if(!(groene == null))
                {
                    writer.WriteLine("Groene Ruimte Project ID | Oppervlakte | Biodiversiteits Score | Aantal WandelPaden | Is opgenomen in wandelroutes | Beoordeling Bezoekers |");
                    string groen = string.Join('|', groene.ID, groene.OppervlakteVierkanteM, groene.BiodiversiteitsScore, groene.AantalWandelpaden, groene.IsOpgenomenInWandelroute, groene.BeoordelingBezoekers);
                    writer.WriteLine(groen);
                    writer.WriteLine("Faciliteit");
                    foreach(Faciliteit faciliteit in groene.Faciliteiten)
                    {
                        writer.WriteLine(faciliteit.Soort);
                    }
                }
                if (!(inno == null))
                {
                    writer.WriteLine("Innovatief Wonen ID | Aantal Wooneenheden | Is Rondleiding Mogelijk | Is Showwoning Beschikbaar | Architecturele score | In Samenwerking met Erfgoed of Toerisme Gent |");
                    string innov = string.Join('|', inno.ID, inno.AantalWooneenheden, inno.IsRondleidingMogelijk, inno.IsShowwoningBeschikbaar, inno.ArchitecturaleScore, inno.HeeftSamenwerkingErfgoedOfToerismeGent);
                    writer.WriteLine(innov);
                    writer.WriteLine("Woonvormen");
                    foreach(Woonvorm woonvorm in inno.TypeWoonvormen)
                    {
                        writer.WriteLine(woonvorm.Soort);
                    }
                }
                if (!(stads == null))
                {
                    writer.WriteLine("Stadsontwikkelings Project ID | Status Vergunning | Heeft Architecturele Waarde | Toegankelijkheid | Is Bezienswaardig | Heeft een uitlegbord of infowandeling |");
                    string stedelijk = string.Join('|', stads.ID, stads.VergunStatus.ToString(), stads.HeeftArchitectureleWaarde, stads.Toegankelijkheid.ToString(), stads.IsBezienswaardig, stads.HeeftUitlegbordOfInfoWandeling);
                }

            }

        }

        public void ExportToPdf(Project project)
        {
            throw new NotImplementedException();
        }

        public void GenerateProjectFiche(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
