using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ComplaintTypeRepository : IRepository<ComplaintType>
    {
        private ElectionsContext db;

        public ComplaintTypeRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(ComplaintType item)
        {
            db.ComplaintTypes.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.ComplaintTypes.Find(id);
            if (item != null)
                db.ComplaintTypes.Remove(item);
        }

        public IEnumerable<ComplaintType> Find(Func<ComplaintType, bool> predicate)
        {
            return db.ComplaintTypes.Where(predicate).ToList();
        }

        public ComplaintType Get(int id)
        {
            return db.ComplaintTypes.Find(id);
        }

        public IEnumerable<ComplaintType> GetAll()
        {
            return db.ComplaintTypes;
        }

        public void Update(ComplaintType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
