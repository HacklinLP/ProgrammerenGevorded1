using JobInterviewBL.Managers;
using JobInterviewBL.Model;
using JobInterviewUI.Mapper;
using JobInterviewUI.Model;
using JobinterviewUtils;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.IO;
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

namespace JobInterviewUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JobInterviewManager manager;
        private ObservableCollection<HREmployeeUI> employees;
        public MainWindow()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            string dbType = config.GetSection("AppSettings")["DBType"];
            manager = new JobInterviewManager(JobinterviewRepositoryFactory.GetJobinterviewRepository(dbType));
            employees = new ObservableCollection<HREmployeeUI>(manager.GetHREmployees().Select(x=>HREmployeeMapper.MapFromDomain(x))); // belangrijk, update de collectie zonder te hoeven refreshen
            DataGridHRMedewerkers.ItemsSource = employees;
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            HREmployeeWindow w = new HREmployeeWindow(false,null);
            bool? result=w.ShowDialog();
            if (result == true)
            {
                var newEmployee = HREmployeeMapper.MapToDomain(w.HREmployee);
                manager.AddHREmployee(newEmployee);
                w.HREmployee.ID=newEmployee.ID;
                employees.Add(w.HREmployee);
            }
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = DataGridHRMedewerkers.SelectedItem;
            if (item != null)
            {
                employees.Remove((HREmployeeUI)item);
                manager.DeleteHREmployee(HREmployeeMapper.MapToDomain((HREmployeeUI)item));
            }
        }

        private void MenuItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            HREmployeeWindow w = new HREmployeeWindow(true, (HREmployeeUI)DataGridHRMedewerkers.SelectedItem);
            bool? result = w.ShowDialog();
            if (result == true)
            {
                manager.UpdateHREmployee(HREmployeeMapper.MapToDomain(w.HREmployee));               
            }
        }

        private void MenuItemInterview_Click(object sender, RoutedEventArgs e)
        {
            InterviewWindow w = new InterviewWindow(manager);
            w.ShowDialog();
        }
    }
}