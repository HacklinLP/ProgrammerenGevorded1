using JobInterviewBL.Interfaces;
using JobInterviewBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobInterviewDL
{
    public class JobInterviewRepositoryMemory : IJobInterviewRepository
    {
        private List<Expert> experts = new();
        private Dictionary<int,HREmployee> employees=new();
        private int employeeID = 1;

        public JobInterviewRepositoryMemory()
        {
            employees.Add(employeeID,new HREmployee(employeeID, "Jos", "jos@gmail", "012345", "Finance")); employeeID++;
            employees.Add(employeeID, new HREmployee(employeeID, "Julie", "julie@gmail", "9012345", "Finance")); employeeID++;
            employees.Add(employeeID, new HREmployee(employeeID, "Eddy", "eddy@gmail", "2012345", "IT")); employeeID++;
            employees.Add(employeeID, new HREmployee(employeeID, "Maria", "maria@gmail", "7012345", "HR")); employeeID++;
            experts.Add(new Expert("Jos", "Databanken"));
            experts.Add(new Expert("Julie", "Finance"));
            experts.Add(new Expert("Jani", "Java"));
            experts.Add(new Expert("Luc", ".NET"));
            experts.Add(new Expert("Marie", "Security"));
        }
        public void AddHREmployee(HREmployee hREmployee)
        {
            hREmployee.ID = employeeID++;
            employees.Add(hREmployee.ID,hREmployee);
        }

        public void DeleteHREmployee(HREmployee hREmployee)
        {
            employees.Remove(hREmployee.ID);
        }

        public List<HREmployee> GetHREmployees()
        {
            return employees.Values.ToList();
        }
        public void UpdateHREmployee(HREmployee hREmployee)
        {
            employees[hREmployee.ID] = hREmployee;
        }

        public List<Expert> GetExperts()
        {
            return experts;
        }
    }
}
