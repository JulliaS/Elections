using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class DistrictRepository : IRepository<District>
    {
        private ElectionsContext db;

        public DistrictRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(District item)
        {
            db.Districts.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Districts.Find(id);
            if (item != null)
                db.Districts.Remove(item);
        }

        public IEnumerable<District> Find(Func<District, bool> predicate)
        {
            return db.Districts.Where(predicate).ToList();
        }

        public District Get(int id)
        {
            return db.Districts.Find(id);
        }

        public IEnumerable<District> GetAll()
        {
            return db.Districts;
        }

        public void Update(District item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
