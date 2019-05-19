using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class AppealRepository : IRepository<Appeal>
    {
        private ElectionsContext db;

        public AppealRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Appeal item)
        {
            db.Appeals.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Appeals.Find(id);
            if (item != null)
                db.Appeals.Remove(item);
        }

        public IEnumerable<Appeal> Find(Func<Appeal, bool> predicate)
        {
            return db.Appeals.Where(predicate).ToList();
        }

        public Appeal Get(int id)
        {
            return db.Appeals.Find(id);
        }

        public IEnumerable<Appeal> GetAll()
        {
            return db.Appeals;
        }

        public void Update(Appeal item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
