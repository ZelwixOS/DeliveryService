using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class TransportRepository : IRepository<Transport>
    {
        private DSdb db;

        public TransportRepository(DSdb dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Transport> GetList()
        {
            return db.Transport.ToList();
        }

        public Transport GetItem(int id)
        {
            return db.Transport.Find(id);
        }

        public void Create(Transport item)
        {
            db.Transport.Add(item);
        }

        public void Update(Transport item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Transport item = db.Transport.Find(id);
            if (item != null)
                db.Transport.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
