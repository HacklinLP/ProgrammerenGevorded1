using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Interfaces;
using StadontwikkelingGentDL.Repositories;
using StadontwikkelingGentUI;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StadOntwikkelingGentUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Gebruiker _gebruiker;
    private readonly IPartnerRepository _partners;
    private readonly IGebruikerRepository _gebruikers;
    private readonly IProjectRepository _projecten;
    private List<ProjectDTOUi> _modelProjecten;
    public MainWindow()
    {

    }
    public MainWindow(IPartnerRepository partnerRepository, IGebruikerRepository gebruikerRepository, IProjectRepository projectRepository, Gebruiker gebruiker)
    {
        InitializeComponent();
        _gebruikers = gebruikerRepository;
        _projecten = projectRepository;
        _partners = partnerRepository;
        _gebruiker = gebruiker;
        _modelProjecten = gebruiker.GebrProjectenDTO.ToList();
        DataGridProjecten.ItemsSource = _modelProjecten;

    }

    private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        // Ensure the double click was on a row and not a blank area
        if (sender is DataGridRow row)
        {
            // Get the underlying data object associated with the row
            if (row.Item is ProjectDTOUi selectedProduct)
            {
                // Open the new window and pass the selected data
                var detailWindow = new ProjectInfoWindow(selectedProduct, _projecten);
                detailWindow.Show();
            }
        }
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
            try
            {
                ProjectficheEditorWindow projectficheEditorWindow = new ProjectficheEditorWindow(_partners, _gebruikers, _projecten, _gebruiker, selectedProject.Id);
                projectficheEditorWindow.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
    private void ButtonVoegToe_Click(object sender, RoutedEventArgs e)
    {
        ProjectMakerWindow projectMakerWindow = new(_projecten, _partners, _gebruikers, _gebruiker);
        projectMakerWindow.Show();
        this.Close();
    }

    public void ButtonVerwijder_Click(object sender, RoutedEventArgs e)
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
            Project verwijdertProject = _projecten.GeefProjectOpId(selectedProject.Id);
            _modelProjecten.Remove(selectedProject);
            _projecten.VerwijderProject(verwijdertProject);

            MessageBox.Show("Verwijderen project gelukt!", 
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void ButtonToonAlle_Click(object sender, RoutedEventArgs e)
    {
        AllProjectsWindow allProjectsWindow = new AllProjectsWindow(_gebruiker, _projecten);
        allProjectsWindow.Show();
        this.Close();
    }

    private void ButtonProjectfiche_Click(object sender, RoutedEventArgs e)
    {
        ProjectDTOUi selectedProject = DataGridProjecten.SelectedItem as ProjectDTOUi;

        if (selectedProject == null)
        {
            MessageBox.Show("Gelieve een project te kiezen.",
                "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        ProjectInfoWindow ProjectInfo = new ProjectInfoWindow(selectedProject, _projecten);
        ProjectInfo.Show();
    }
}