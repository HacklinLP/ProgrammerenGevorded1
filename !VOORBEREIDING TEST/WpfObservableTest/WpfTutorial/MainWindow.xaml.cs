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

namespace WpfTutorial;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = this;
        entries = new ObservableCollection<string>(); // altijd doen voor de init
        InitializeComponent();
    }

    private ObservableCollection<string> entries;

    public ObservableCollection<string> Entries
    {
        get { return entries; }
        set { entries = value; }
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        Entries.Add(txtEntry.Text);
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        string selectedItem = (string)lvEntries.SelectedItem;
        Entries.Remove(selectedItem);
    }

    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        Entries.Clear();
    }
}