using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ChermanOfDistrictRepository : IRepository<ChermanOfDistrict>
    {
        private ElectionsContext db;

        public ChermanOfDistrictRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(ChermanOfDistrict item)
        {
            db.ChermanOfDistricts.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.ChermanOfDistricts.Find(id);
            if (item != null)
                db.ChermanOfDistricts.Remove(item);
        }

        public IEnumerable<ChermanOfDistrict> Find(Func<ChermanOfDistrict, bool> predicate)
        {
            return db.ChermanOfDistricts.Where(predicate).ToList();
        }

        public ChermanOfDistrict Get(int id)
        {
            return db.ChermanOfDistricts.Find(id);
        }

        public IEnumerable<ChermanOfDistrict> GetAll()
        {
            return db.ChermanOfDistricts;
        }

        public void Update(ChermanOfDistrict item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
