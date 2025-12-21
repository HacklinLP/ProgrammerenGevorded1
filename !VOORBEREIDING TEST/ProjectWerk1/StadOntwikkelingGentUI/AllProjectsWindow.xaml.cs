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
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;

namespace StadontwikkelingGentUI
{
    /// <summary>
    /// Interaction logic for AllProjectsWindow.xaml
    /// </summary>
    public partial class AllProjectsWindow : Window
    {
        private readonly Gebruiker _gebruiker;
        private readonly IProjectRepository _projectRepository;
        public AllProjectsWindow(Gebruiker gebruiker, IProjectRepository projectRepsitory)
        {
            InitializeComponent();

            _gebruiker = gebruiker;
            _projectRepository = projectRepsitory;

            LaadProjecten();
        }

        public void LaadProjecten()
        {
            List<Project> projecten = _gebruiker.GebrProjecten;
            DataGridAlleProjecten.ItemsSource = projecten;
        }
    }
}
