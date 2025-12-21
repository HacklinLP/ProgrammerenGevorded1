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
    /// Interaction logic for GebruikerWindowxaml.xaml
    /// </summary>
    public partial class GebruikerWindow : Window
    {
        private IProjectRepository _projectRepository;
        private IPartnerRepository _partnerRepository;
        private IGebruikerRepository _gebruikerRepository;
        List<Gebruiker> _gebruikers;
        private Gebruiker _gebruiker;
        public GebruikerWindow(IPartnerRepository partnerRepository, IGebruikerRepository gebruikerRepository, IProjectRepository projectRepository, Gebruiker gebruiker)
        {
            InitializeComponent();
        _projectRepository = projectRepository;
            _partnerRepository = partnerRepository;
            _gebruikerRepository = gebruikerRepository;
            _gebruiker = gebruiker;
            _gebruikers = _gebruikerRepository.GeefAlleGebruikers();
            DataGridGebruikers.ItemsSource = _gebruikers;
        }

        private void VoegGebruikerToe_Click(object sender, RoutedEventArgs e)
        {

        }
        private void VerwijderGebruiker_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
