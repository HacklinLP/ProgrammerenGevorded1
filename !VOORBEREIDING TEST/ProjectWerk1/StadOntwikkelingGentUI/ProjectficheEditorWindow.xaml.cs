using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Interfaces;
using StadontwikkelingGentDL.Repositories;
using StadOntwikkelingGentUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Reflection.Metadata;
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

namespace StadontwikkelingGentUI
{
    /// <summary>
    /// Interaction logic for ProjectficheExportWindow.xaml
    /// </summary>
    public partial class ProjectficheEditorWindow : Window
    {
        private IProjectRepository _projectRepository;
        private IPartnerRepository _partnerRepository;
        private IGebruikerRepository _gebruikerRepository;
        private Gebruiker _gebruiker;
        private Project _project;
        public ProjectficheEditorWindow(IPartnerRepository partnerRepository, IGebruikerRepository gebruikerRepository, IProjectRepository projectRepository, Gebruiker gebruiker,int projectId)
        {
            InitializeComponent();
            
            _projectRepository = projectRepository;
            _partnerRepository = partnerRepository;
            _gebruikerRepository = gebruikerRepository;
            _gebruiker = gebruiker;
            _project = _projectRepository.GeefProjectOpId(projectId);

            ComboBoxStatusVergunning.ItemsSource = Enum.GetValues(typeof(VergunningStatus));
            ComboBoxToegankelijkheid.ItemsSource = Enum.GetValues(typeof(OpenbareToegankelijkheid));
            ComboBoxStatus.ItemsSource = Enum.GetValues(typeof(StatusProject));

            LaadMainProjectInfo();
            LaadTypeProjectInfo();

            this.Closed += new EventHandler(Window_Closed);
        }

        private void LaadMainProjectInfo()
        {
            TextBoxNaam.Text = _project.Titel;
            DatePickerStartDatum.SelectedDate = _project.StartDatum;
            ComboBoxStatus.SelectedItem = _project.Status;
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
                switch (typeProject)
                {

                    case StadsOntwikkelingsProject stad:
                        ComboBoxStatusVergunning.SelectedItem = stad.VergunStatus;
                        CheckBoxArchitecturalewaarde.IsChecked = stad.HeeftArchitectureleWaarde;
                        ComboBoxToegankelijkheid.SelectedItem = stad.Toegankelijkheid;
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
        public Project PasProjectAan()
        {
            string titel = TextBoxNaam.Text;

            DateTime? startDatum;
            try
            {
                startDatum = DatePickerStartDatum.SelectedDate;
            }
            catch
            {
                startDatum = null;
            }
            
            StatusProject Project = (StatusProject)Enum.Parse(typeof(StatusProject), ComboBoxStatus.SelectedItem.ToString());
            string Beschrijving = TextBoxBeschrijving.Text;
            string Straat = TextBoxStraatnaam.Text;
            string Huisnummer = TextBoxHuisnummer.Text;
            string Gemeente = TextBoxGemeente.Text;
            string Provincie = TextBoxProvincie.Text;
            string Wijk = TextBoxWijk.Text;

            Adres Adres = new Adres(Straat, Huisnummer, Gemeente, Provincie, Wijk);
            List<Partner> Partners = new List<Partner>();
            List<TypeProject> TypeProject = new List<TypeProject>();

            if (!string.IsNullOrEmpty(ComboBoxStatusVergunning.Text))
            {
                VergunningStatus vergunningStatus = (VergunningStatus)Enum.Parse(typeof(VergunningStatus), ComboBoxStatusVergunning.SelectedItem.ToString());
                bool HeeftArchitecturaleWaarde = CheckBoxArchitecturalewaarde.IsChecked == true;
                OpenbareToegankelijkheid Toegankelijkheid = (OpenbareToegankelijkheid)Enum.Parse(typeof(OpenbareToegankelijkheid), ComboBoxToegankelijkheid.SelectedItem.ToString());
                bool IsBezienswaardig = CheckBoxIsBezienswaardig.IsChecked == true;
                bool InfoVoorzien = CheckBoxUitlegBord.IsChecked == true;

                StadsOntwikkelingsProject sop = new StadsOntwikkelingsProject(vergunningStatus, HeeftArchitecturaleWaarde, Toegankelijkheid, IsBezienswaardig, InfoVoorzien);
                TypeProject.Add(sop);
            }
            if (!string.IsNullOrEmpty(TextBoxAantalWandelpaden.Text))
            {
                double Oppervlakte = double.Parse(TextBoxOppervlakte.Text);
                int Biodiversiteit = int.Parse(TextBoxBiodiversiteit.Text);
                int AantalWandelpaden = int.Parse(TextBoxAantalWandelpaden.Text);
                List<Faciliteit> BeschikbareFaciliteiten = new List<Faciliteit>();
                bool HeeftWandelroute = CheckBoxWandelroute.IsChecked == true;
                int BeoordelingBezoekers = int.Parse(TextBoxBeoordelingBezoekers.Text);

                GroeneRuimteProject grp = new GroeneRuimteProject(Oppervlakte, Biodiversiteit, AantalWandelpaden, BeschikbareFaciliteiten, HeeftWandelroute, BeoordelingBezoekers);
                TypeProject.Add(grp);
            }
            if (!string.IsNullOrEmpty(TextBoxAantalWooneenheden.Text))
            {
                int AantalWooneenheden = int.Parse(TextBoxAantalWooneenheden.Text);
                List<Woonvorm> TypeWoonvormen = new List<Woonvorm>();
                bool HeeftRondleiding = CheckBoxRondleiding.IsChecked == true;
                bool IsShowwoning = CheckBoxShowwoning.IsChecked == true;
                int ArchitecturaleScore = int.Parse(TextBoxArchitecturaleScore.Text);
                bool SamenwerkingErfgoed = CheckBoxSamenwerkingErfgoed.IsChecked == true;

                InnovatiefWonenProject iwp = new InnovatiefWonenProject(AantalWooneenheden, TypeWoonvormen, HeeftRondleiding, IsShowwoning, ArchitecturaleScore, SamenwerkingErfgoed);
                TypeProject.Add(iwp);
            }

            Project project = new Project(titel, startDatum, Project, Beschrijving, Adres, Partners, TypeProject);

            return project;
        }

        public void ButtonPasAan_Click(object sender, RoutedEventArgs e)
        {

            Project project = PasProjectAan();
            _projectRepository.UpdateProject(project);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_gebruiker.IsAdmin)
            {
                AdminMainWindow adminMainWindow = new(_partnerRepository, _gebruikerRepository, _projectRepository, _gebruiker);
                adminMainWindow.Show();
    }
            else
            {
                MainWindow mainWindow = new MainWindow(_partnerRepository, _gebruikerRepository, _projectRepository, _gebruiker);
                mainWindow.Show();
            }
        }


        private void ButtonTypeWoonvormen_Click(object sender, EventArgs e)
        {

        }

        private void ButtonBeschikbareFaciliteiten_Click(object sender, EventArgs e)
        {

        }

        private void ButtonVoegPartnerToe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
