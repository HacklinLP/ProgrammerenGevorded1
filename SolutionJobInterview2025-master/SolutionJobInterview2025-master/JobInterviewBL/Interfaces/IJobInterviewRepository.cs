using JobInterviewBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobInterviewBL.Interfaces
{
    public interface IJobInterviewRepository
    {
        void AddHREmployee(HREmployee hREmployee);
        void DeleteHREmployee(HREmployee hREmployee);
        List<Expert> GetExperts();
        List<HREmployee> GetHREmployees();
        void UpdateHREmployee(HREmployee hREmployee);
    }
}
