using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using BLL.Models;

namespace BLL
{
    public class dbOperations : IdbCrud
    {
        IdbOperations db;

        public dbOperations(IdbOperations repos)
        {
            db = repos;
        }

        #region Order
        public List<OrderModel> GetAllOrders()
        {
            return db.Orders.GetList().Select(i => new OrderModel(i)).ToList();
        }
        #endregion

        #region Status
        public List<StatusModel> GetAllStatuses()
        {
            return db.Statuses.GetList().Select(i=> new StatusModel(i)).ToList();
        }

        #endregion

        public int Save()
        {
            int SaveCh = 0;
            try
            {
                SaveCh = db.Save();
            }
            catch (Exception e)
            {
                return 2;
            }
            if (SaveCh > 0) return 1;
            return 0;
        }

    }
}
