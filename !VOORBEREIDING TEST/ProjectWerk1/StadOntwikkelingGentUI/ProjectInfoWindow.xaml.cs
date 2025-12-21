using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.IdentityModel.Tokens;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Interfaces;
using Utils;

namespace StadontwikkelingGentUI
{
    /// <summary>
    /// Interaction logic for ProjectInfoWindow1.xaml
    /// </summary>
    public partial class ProjectInfoWindow : Window
    {
        private readonly Project _project;
        public ProjectInfoWindow(ProjectDTOUi project, IProjectRepository projectRepository)
        {
            InitializeComponent();

            _project = projectRepository.GeefProjectOpId(project.Id);

            LaadMainProjectInfo();
            LaadTypeProjectInfo();
        }

        private void LaadMainProjectInfo()
        {
            TextBoxNaam.Text = _project.Titel;
            DatePickerStartDatum.SelectedDate = _project.StartDatum;
            TextBoxStatus.Text = _project.Status.ToString();
            TextBoxBeschrijving.Text = _project.Beschrijving;
            TextBoxStraatnaam.Text = _project.Locatie.Straat;
            TextBoxHuisnummer.Text = _project.Locatie.Huisnummer;
            TextBoxGemeente.Text = _project.Locatie.Gemeente;
            TextBoxProvincie.Text = _project.Locatie.Provincie;
            TextBoxWijk.Text = _project.Locatie.Wijk;
        }

        private void LaadTypeProjectInfo()
        {
            foreach (var typeProject in _project.ProjectTypes)
            {
                switch(typeProject)
                {

                    case StadsOntwikkelingsProject stad:
                        TextBoxStatusVergunning.Text = stad.VergunStatus.ToString();
                        CheckBoxArchitecturalewaarde.IsChecked = stad.HeeftArchitectureleWaarde;
                        TextBoxToegankelijkheid.Text = stad.Toegankelijkheid.ToString();
                        CheckBoxIsBezienswaardig.IsChecked = stad.IsBezienswaardig;
                        CheckBoxUitlegBord.IsChecked = stad.HeeftUitlegbordOfInfoWandeling;
                        break;

                    case InnovatiefWonenProject innovatief:
                        TextBoxAantalWooneenheden.Text = innovatief.AantalWooneenheden.ToString();
                        CheckBoxRondleiding.IsChecked = innovatief.IsRondleidingMogelijk;
                        CheckBoxShowwoning.IsChecked = innovatief.IsShowwoningBeschikbaar;
                        TextBoxArchitecturaleScore.Text = innovatief.ArchitecturaleScore.ToString();
                        CheckBoxSamenwerkingErfgoed.IsChecked = innovatief.HeeftSamenwerkingErfgoedOfToerismeGent;
                        break;

                    case GroeneRuimteProject groen:
                        TextBoxOppervlakte.Text = groen.OppervlakteVierkanteM.ToString();
                        TextBoxBiodiversiteit.Text = groen.BiodiversiteitsScore.ToString();
                        TextBoxAantalWandelpaden.Text = groen.AantalWandelpaden.ToString();
                        CheckBoxWandelroute.IsChecked = groen.IsOpgenomenInWandelroute;
                        TextBoxBeoordelingBezoekers.Text = groen.BeoordelingBezoekers.ToString();
                        break;
                }
            }
        }
        public void ButtonPrintFiche_Click(object sender, RoutedEventArgs e)
        {
            RepositoryFactory factory = new();
            IReportGenerator generator = factory.GeefReportGenerator();
            generator.ExportToCsv(_project);
        }
    }
}
