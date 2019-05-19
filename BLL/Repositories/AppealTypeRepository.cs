using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class AppealTypeRepository : IRepository<AppealType>
    {
        private ElectionsContext db;

        public AppealTypeRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(AppealType item)
        {
            db.AppealTypes.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.AppealTypes.Find(id);
            if (item != null)
                db.AppealTypes.Remove(item);
        }

        public IEnumerable<AppealType> Find(Func<AppealType, bool> predicate)
        {
            return db.AppealTypes.Where(predicate).ToList();
        }

        public AppealType Get(int id)
        {
            return db.AppealTypes.Find(id);
        }

        public IEnumerable<AppealType> GetAll()
        {
            return db.AppealTypes;
        }

        public void Update(AppealType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
