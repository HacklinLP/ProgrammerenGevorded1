using JobInterviewBL.Model;
using JobInterviewUI.Model;
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
    /// Interaction logic for HREmployeeWindow.xaml
    /// </summary>
    public partial class HREmployeeWindow : Window
    {
        public HREmployeeUI HREmployee { get; set; }
        private bool isUpdate;
        public HREmployeeWindow(bool isUpdate,HREmployeeUI hREmployee)
        {
            InitializeComponent();
            this.isUpdate = isUpdate;
            if (isUpdate)
            {
                ButtonHREmployee.Content = "Update";
                HREmployee = hREmployee;
                TextBoxEmail.Text = HREmployee.Email;
                TextBoxId.Text=HREmployee.ID.ToString();
                TextBoxExpertise.Text = HREmployee.Expertise;
                TextBoxPhone.Text = HREmployee.Phone;
                TextBoxName.Text = HREmployee.Name;
            }
            else
            {
                ButtonHREmployee.Content = "New";
            }
        }

        private void ButtonNewUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isUpdate)
                {
                    HREmployee.Email= TextBoxEmail.Text;
                    HREmployee.Name= TextBoxName.Text;
                    HREmployee.Expertise= TextBoxExpertise.Text;
                    HREmployee.Phone= TextBoxPhone.Text;
                }
                else
                {
                    HREmployee = new HREmployeeUI(TextBoxName.Text, TextBoxEmail.Text, TextBoxPhone.Text, TextBoxExpertise.Text);
                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
