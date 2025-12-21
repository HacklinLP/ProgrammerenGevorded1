using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;
using StadOntwikkelingGentUI;

namespace StadontwikkelingGentUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProjectMakerWindow : Window
    {
        private IProjectRepository _repository;
        private IPartnerRepository _partnerRepository;
        private IGebruikerRepository _gebruikerRepository;
        private Gebruiker _gebruiker;
        public ProjectMakerWindow(IProjectRepository projectRepository, IPartnerRepository partnerRepo, IGebruikerRepository gebruikerRepo, Gebruiker gebruiker)
        {
            InitializeComponent();

            _repository = projectRepository;
            _partnerRepository = partnerRepo;
            _gebruikerRepository = gebruikerRepo;
            _gebruiker = gebruiker;
            int[] totVijf = { 1, 2, 3, 4, 5 };
            int[] totTien = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ComboBoxStatusVergunning.ItemsSource = Enum.GetValues(typeof(VergunningStatus));
            ComboBoxToegankelijkheid.ItemsSource = Enum.GetValues(typeof(OpenbareToegankelijkheid));
            ComboBoxStatus.ItemsSource = Enum.GetValues(typeof(StatusProject));
            ComboBoxArchitecturaleScore.ItemsSource = totTien;
            ComboBoxBiodiversiteit.ItemsSource = totTien;
            ComboBoxBeoordelingBezoekers.ItemsSource = totVijf;
            this.Closed += Window_Close;
        }

        public Project MaakProjectAan()
        {
            string titel = TextBoxNaam.Text;
            DateTime? StartDatum = DatePickerStartDatum.SelectedDate;
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
                int Biodiversiteit = int.Parse(ComboBoxBiodiversiteit.SelectedItem.ToString());
                int AantalWandelpaden = int.Parse(TextBoxAantalWandelpaden.Text);
                List<Faciliteit> BeschikbareFaciliteiten = new List<Faciliteit>();
                bool HeeftWandelroute = CheckBoxWandelroute.IsChecked == true;

                int BeoordelingBezoekers = int.Parse(ComboBoxBeoordelingBezoekers.SelectedItem.ToString());

                GroeneRuimteProject grp = new GroeneRuimteProject(Oppervlakte, Biodiversiteit, AantalWandelpaden, BeschikbareFaciliteiten, HeeftWandelroute, 5);
                TypeProject.Add(grp);
            }
            if(!string.IsNullOrEmpty(TextBoxAantalWooneenheden.Text))
            {
                int AantalWooneenheden = int.Parse(TextBoxAantalWooneenheden.Text);
                List<Woonvorm> TypeWoonvormen = new List<Woonvorm>();
                bool HeeftRondleiding = CheckBoxRondleiding.IsChecked == true;
                bool IsShowwoning = CheckBoxShowwoning.IsChecked == true;
                int ArchitecturaleScore = int.Parse(ComboBoxArchitecturaleScore.SelectedItem.ToString());
                bool SamenwerkingErfgoed = CheckBoxSamenwerkingErfgoed.IsChecked == true;

                InnovatiefWonenProject iwp = new InnovatiefWonenProject(AantalWooneenheden, TypeWoonvormen, HeeftRondleiding, IsShowwoning, ArchitecturaleScore, SamenwerkingErfgoed);
                TypeProject.Add(iwp);
            }

            Project project = new Project(titel, StartDatum, Project, Beschrijving, Adres, Partners, TypeProject);

            return project;
        }

        public void ButtonMaakAan_Click(object sender, RoutedEventArgs e)
        {
            Project project = MaakProjectAan();
            _repository.VoegProjectIn(project, _gebruiker.Id);

            MessageBox.Show("Project succesvol aangemaakt!", 
                "Info", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Window_Close(object? sender, EventArgs e)
        {

            if(_gebruiker.IsAdmin)
            {
                AdminMainWindow AdminMain = new AdminMainWindow(_partnerRepository, _gebruikerRepository, _repository, _gebruiker);
                Application.Current.MainWindow = AdminMain;
                AdminMain.Show();
            }
            else
            {
                MainWindow main = new MainWindow(_partnerRepository, _gebruikerRepository, _repository, _gebruiker);
                Application.Current.MainWindow = main;
                main.Show();
            }
        }

        private void ButtonTypeWoonvormen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBeschikbareFaciliteiten_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
