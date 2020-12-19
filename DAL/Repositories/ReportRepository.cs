using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repositories
{
    public class ReportRepository: IReportsReprository
    {
        private DSdb db;

        public ReportRepository(DSdb dbcontext)
        {
            db = dbcontext;
        }

        public class preResSalary
        {
            public int ID { get; set; }
            public string CourierName { get; set; }
            public double Price { get; set; }
            public int? Car { get; set; }
        }

        public List<CourierSalaryModel> CountAllSalaries(DateTime s, DateTime f)
        {
            var PreRes = (from cour in db.Courier
                           join deliv in db.Delivery
                           on cour.ID equals deliv.Courier_ID_FK
                           where (s <= deliv.Date && f >= deliv.Date)
                           select new preResSalary
                           {
                               ID = cour.ID,
                               CourierName = cour.CourierName,
                               Price = deliv.Distance * deliv.KmPrice,
                               Car = deliv.Transport_ID_FK
                           }).ToList();

            foreach (preResSalary ps in PreRes)
                if (ps.Car != null || ps.Car != 1)
                    ps.Price = ps.Price * 0.75;
            var CourSal = (from pr in PreRes
                          group pr by new { pr.ID, pr.CourierName } into g
                          select new CourierSalaryModel
                          {
                              ID = g.Key.ID,
                              CourierName = g.Key.CourierName,
                              Salary = g.Sum(x => x.Price)
                          } ).ToList();
            return CourSal;
        }
    }
}
