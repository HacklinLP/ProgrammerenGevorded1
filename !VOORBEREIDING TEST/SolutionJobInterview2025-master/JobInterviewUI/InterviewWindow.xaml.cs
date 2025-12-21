using JobInterviewBL.Managers;
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

namespace JobInterviewUI
{
    /// <summary>
    /// Interaction logic for InterviewWindow.xaml
    /// </summary>
    public partial class InterviewWindow : Window
    {
        private JobInterviewManager manager;
        public InterviewWindow(JobInterviewManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void ButtonExperts_Click(object sender, RoutedEventArgs e)
        {
            ExpertsWindow w = new ExpertsWindow(manager);
            w.ShowDialog();
        }
    }
}
