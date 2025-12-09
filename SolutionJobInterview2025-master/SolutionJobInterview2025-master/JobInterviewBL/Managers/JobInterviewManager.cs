using JobInterviewBL.Interfaces;
using JobInterviewBL.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobInterviewBL.Managers
{
    public class JobInterviewManager
    {
        private IJobInterviewRepository repository;

        public JobInterviewManager(IJobInterviewRepository repository)
        {
            this.repository = repository;
        }

        public void AddHREmployee(HREmployee hREmployee)
        {
           repository.AddHREmployee(hREmployee);
        }

        public void DeleteHREmployee(HREmployee hREmployee)
        {
            repository.DeleteHREmployee(hREmployee);
        }
        public List<Expert> GetExperts()
        {
            return repository.GetExperts();
        }
        public List<HREmployee> GetHREmployees()
        {
            return repository.GetHREmployees();
        }

        public void UpdateHREmployee(HREmployee hREmployee)
        {
            repository.UpdateHREmployee(hREmployee);
        }
    }
}
