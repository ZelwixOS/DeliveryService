using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CourierSalary: ICourierSalary
    {
        IReportsReprository reports;
        public List<CourierSalaryModel> CountAllSalaries(DateTime s, DateTime f)
        {
            var CourSal = reports.CountAllSalaries(s, f).Select(i => new CourierSalaryModel { ID = i.ID, CourierName=i.CourierName, Salary=i.Salary }).ToList();
            return CourSal;
        }

        public CourierSalary(IReportsReprository rep)
        {
            reports = rep;
        }
    }
}
