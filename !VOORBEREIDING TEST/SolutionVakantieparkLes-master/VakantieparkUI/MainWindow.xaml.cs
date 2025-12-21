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
using VakantieparkBL.Services;
using VakantieparkDL;

namespace VakantieparkUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VakantieparkService vakantieparkService=new VakantieparkService(new VakantieparkRepositoryMemory());
        public MainWindow()
        {
            InitializeComponent();
            DataGridVakantieparken.ItemsSource = vakantieparkService.GeefVakantieparken();
        }
    }
}