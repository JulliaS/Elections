using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class CitizenRepository : IRepository<Citizen>
    {
        private ElectionsContext db;

        public CitizenRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Citizen item)
        {
            db.Citizens.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Citizens.Find(id);
            if (item != null)
                db.Citizens.Remove(item);
        }

        public IEnumerable<Citizen> Find(Func<Citizen, bool> predicate)
        {
            return db.Citizens.Where(predicate).ToList();
        }

        public Citizen Get(int id)
        {
            return db.Citizens.Find(id);
        }

        public IEnumerable<Citizen> GetAll()
        {
            return db.Citizens;
        }

        public void Update(Citizen item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
