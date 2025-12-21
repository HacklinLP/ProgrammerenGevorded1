using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobInterviewUI.Model
{   
    public class HREmployeeUI : INotifyPropertyChanged
    {
        public HREmployeeUI(string name, string email, string phone, string expertise)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Expertise = expertise;
        }

        public HREmployeeUI(int iD, string name, string email, string phone, string expertise)
        {
            ID = iD;
            Name = name;
            Email = email;
            Phone = phone;
            Expertise = expertise;
        }

        public int ID { get; set; }
        private string name;
        public string Name { 
            get =>name;
            set { name = value;OnPropertyChanged("Name"); } }
        private string email;
        public string Email { 
            get=>email; 
            set { email = value; OnPropertyChanged(null); } }
        public string Phone { get; set; }
        public string Expertise { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
