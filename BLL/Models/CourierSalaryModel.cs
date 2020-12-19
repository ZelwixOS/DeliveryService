using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
    public class CourierSalaryModel
    {
        public int ID { get; set; }

        public string CourierName { get; set; }

        public double Salary { get; set; }

        public CourierSalaryModel(Courier c, double m)
        {
            ID = c.ID;
            CourierName = c.CourierName;
            Salary = m;
        }
        public CourierSalaryModel() { }

    }
}
