using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Interfaces;
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

namespace StadontwikkelingGentUI
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private IProjectRepository _projectRepository;
        private IPartnerRepository _partnerRepository;
        private IGebruikerRepository _gebruikerRepository;
        private Gebruiker _gebruiker;
        private List<ProjectDTOUi> _modelProjecten;
        public AdminMainWindow(IPartnerRepository partnerRepository, IGebruikerRepository gebruikerRepository, IProjectRepository projectRepository, Gebruiker gebruiker)
        {
            InitializeComponent();
            _gebruikerRepository = gebruikerRepository;
            _projectRepository = projectRepository;
            _partnerRepository = partnerRepository;
            _gebruiker = gebruiker;
            _modelProjecten = projectRepository.GeefAlleProjecten();
            DataGridProjecten.ItemsSource = _modelProjecten;
        }

        private void ButtonPasAan_Click(object sender, RoutedEventArgs e)
        {
            ProjectDTOUi selectedProject = DataGridProjecten.SelectedItem as ProjectDTOUi;
            if (selectedProject == null)
            {
                MessageBox.Show("Gelieve een project te kiezen.",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                ProjectficheEditorWindow projectficheEditorWindow = new ProjectficheEditorWindow(_partnerRepository,_gebruikerRepository,_projectRepository,_gebruiker,selectedProject.Id);
                projectficheEditorWindow.Show();
                this.Close();
            }

        }

        private void ButtonVoegToe_Click(object sender, RoutedEventArgs e)
        {
            ProjectMakerWindow projectMakerWindow = new(_projectRepository, _partnerRepository, _gebruikerRepository, _gebruiker);
            projectMakerWindow.Show();
            this.Close();
        }

        private void ButtonVerwijder_Click(object sender, RoutedEventArgs e)
        {
            ProjectDTOUi selectedProject = DataGridProjecten.SelectedItem as ProjectDTOUi;
            if (selectedProject == null)
            {
                MessageBox.Show("Gelieve een project te kiezen.",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                Project verwijdertProject = _projectRepository.GeefProjectOpId(selectedProject.Id);
                _modelProjecten.Remove(selectedProject);
                _projectRepository.VerwijderProject(verwijdertProject);

            }
        }

        private void ButtonProjectFiche_Click(object sender, RoutedEventArgs e)
        {
            ProjectDTOUi selectedProject = DataGridProjecten.SelectedItem as ProjectDTOUi;

            if (selectedProject == null)
            {
                MessageBox.Show("Gelieve een project te kiezen.",
                    "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ProjectInfoWindow ProjectInfo = new ProjectInfoWindow(selectedProject, _projectRepository);
            ProjectInfo.Show();
        }
    }
}
