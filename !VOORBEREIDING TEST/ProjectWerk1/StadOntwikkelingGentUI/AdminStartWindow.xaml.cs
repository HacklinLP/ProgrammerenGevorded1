using StadontwikkelingGentBL.Domein;
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
    /// Interaction logic for AdminStartWindow.xaml
    /// </summary>
    public partial class AdminStartWindow : Window
    {
        private IProjectRepository _projectRepo;
        private IPartnerRepository _partnerRepo;
        private IGebruikerRepository _gebruikerRepo;
        private Gebruiker _gebruiker;

        public AdminStartWindow(IProjectRepository projectRepo, IPartnerRepository partnerRepo, IGebruikerRepository gebruikerRepo, Gebruiker gebruiker)
        {
            InitializeComponent();
            _projectRepo = projectRepo;
            _partnerRepo = partnerRepo;
            _gebruikerRepo = gebruikerRepo;
            _gebruiker = gebruiker;
        }

        private void Partnerbeheer_Click(object sender, RoutedEventArgs e)
        {
            PartnerWindow partnerWindow = new PartnerWindow(_partnerRepo, _gebruikerRepo, _projectRepo,_gebruiker);
            partnerWindow.Show();

        }

        private void ProjectBeheer_Click(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminMainWindow = new AdminMainWindow(_partnerRepo, _gebruikerRepo, _projectRepo, _gebruiker);
            adminMainWindow.Show();
        }

        private void Gebruikerbeheer_Click(object sender, RoutedEventArgs e)
        {
            GebruikerWindow gebruikerWindow = new(_partnerRepo, _gebruikerRepo, _projectRepo, _gebruiker);
            gebruikerWindow.Show();
        }
    }
}
