using Microsoft.Extensions.Configuration;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;
using StadOntwikkelingGentUI;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Extensions.Configuration;
using Utils;

namespace StadontwikkelingGentUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private readonly IPartnerRepository _partners;
        private readonly IGebruikerRepository _gebruikers;
        private readonly IProjectRepository _projecten;
        public LoginWindow()
        {
            RepositoryFactory repoFactory = new RepositoryFactory();

            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetSection("ConnectionStrings")["SQLserver"];

            _projecten = repoFactory.GeefProjectRepository(connectionString);
            _gebruikers = repoFactory.GeefGebruikerRepository(connectionString);
            _partners = repoFactory.GeefPartnerRepository(connectionString);
        }
        //public LoginWindow(IPartnerRepository partners, IGebruikerRepository gebruikers, IProjectRepository projecten)
        //{
        //    InitializeComponent();

        //    _partners = partners;
        //    _gebruikers = gebruikers;
        //    _projecten = projecten; 
  
        //}

        private void ButtonInloggen_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailVeld.Text.ToLower();
            Gebruiker gebruiker = _gebruikers.GeefGebruikerOpEmail(email);

            bool ifLid = false;
            if (!(gebruiker == null)) ifLid = true;

            bool admin = gebruiker.IsAdmin;
            

            if (ifLid && !admin)
            {
                MainWindow mainWindow = new(_partners, _gebruikers, _projecten, gebruiker);
                mainWindow.Show();
                Close();
            }
            else if (ifLid && admin)
            {
                AdminStartWindow adminStartWindow = new(_projecten, _partners, _gebruikers, gebruiker);
                adminStartWindow.Show();
                Close();
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Gelieve inlogveld in te vullen.",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Verkeerd Emailadres ingevuld. Gelieve opnieuw te proberen.",
                    "Foutmelding",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }


        }
    }
}
