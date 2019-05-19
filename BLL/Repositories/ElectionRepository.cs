using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ElectionRepository : IRepository<Election>
    {
        private ElectionsContext db;

        public ElectionRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Election item)
        {
            db.Elections.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Elections.Find(id);
            if (item != null)
                db.Elections.Remove(item);
        }

        public IEnumerable<Election> Find(Func<Election, bool> predicate)
        {
            return db.Elections.Where(predicate).ToList();
        }

        public Election Get(int id)
        {
            return db.Elections.Find(id);
        }

        public IEnumerable<Election> GetAll()
        {
            return db.Elections;
        }

        public void Update(Election item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
