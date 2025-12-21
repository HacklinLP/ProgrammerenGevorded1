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
    /// Interaction logic for PartnerWindow.xaml
    /// </summary>
    public partial class PartnerWindow : Window
    {

        private IProjectRepository _projectRepository;
        private IPartnerRepository _partnerRepository;
        private IGebruikerRepository _gebruikerRepository;
        List<Partner> _partners;
        private Gebruiker _gebruiker;
        public PartnerWindow(IPartnerRepository partnerRepository, IGebruikerRepository gebruikerRepository, IProjectRepository projectRepository, Gebruiker gebruiker)
        {
            InitializeComponent();
            _projectRepository = projectRepository;
            _partnerRepository = partnerRepository;
            _gebruikerRepository = gebruikerRepository;
            _gebruiker = gebruiker;
            _partners = partnerRepository.GeefAllePartners();
            DataGridPartners.ItemsSource = _partners;
        }

        private void VoegPartnerToe_Click(object sender, RoutedEventArgs e)
        {

        }
        private void VerwijderPartner_Click(object sender, RoutedEventArgs e)
        {

        }

        /*private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
        }*/

    }
}
