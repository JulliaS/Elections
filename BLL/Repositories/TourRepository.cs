using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class TourRepository : IRepository<Tour>
    {
        private ElectionsContext db;

        public TourRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Tour item)
        {
            db.Tours.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Tours.Find(id);
            if (item != null)
                db.Tours.Remove(item);
        }

        public IEnumerable<Tour> Find(Func<Tour, bool> predicate)
        {
            return db.Tours.Where(predicate).ToList();
        }

        public Tour Get(int id)
        {
            return db.Tours.Find(id);
        }

        public IEnumerable<Tour> GetAll()
        {
            return db.Tours;
        }

        public void Update(Tour item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
