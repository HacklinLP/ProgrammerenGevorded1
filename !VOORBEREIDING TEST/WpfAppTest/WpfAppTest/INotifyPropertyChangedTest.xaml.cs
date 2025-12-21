using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace WpfAppTest
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string boundText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set 
            { 
                boundText = value;
                // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoundText"));
                // OnPropertyChanged("BoundText");
                OnPropertyChanged();
            }
        }

        //private void OnPropertyChanged(string propertyName)
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) // .NET automatically knows which property name we're talking about here because it's the name from the caller of this method!
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}