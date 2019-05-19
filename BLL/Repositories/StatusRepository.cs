using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        private ElectionsContext db;

        public StatusRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Status item)
        {
            db.Statuses.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Statuses.Find(id);
            if (item != null)
                db.Statuses.Remove(item);
        }

        public IEnumerable<Status> Find(Func<Status, bool> predicate)
        {
            return db.Statuses.Where(predicate).ToList();
        }

        public Status Get(int id)
        {
            return db.Statuses.Find(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Statuses;
        }

        public void Update(Status item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
