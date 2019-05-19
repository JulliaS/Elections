using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ObserverRepository : IRepository<Observer>
    {
        private ElectionsContext db;

        public ObserverRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Observer item)
        {
            db.Observers.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Observers.Find(id);
            if (item != null)
                db.Observers.Remove(item);
        }

        public IEnumerable<Observer> Find(Func<Observer, bool> predicate)
        {
            return db.Observers.Where(predicate).ToList();
        }

        public Observer Get(int id)
        {
            return db.Observers.Find(id);
        }

        public IEnumerable<Observer> GetAll()
        {
            return db.Observers;
        }

        public void Update(Observer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
