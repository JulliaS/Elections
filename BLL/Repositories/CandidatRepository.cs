using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class CandidatRepository : IRepository<Candidat>
    {
        private ElectionsContext db;

        public CandidatRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Candidat item)
        {
            db.Candidats.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Candidats.Find(id);
            if (item != null)
                db.Candidats.Remove(item);
        }

        public IEnumerable<Candidat> Find(Func<Candidat, bool> predicate)
        {
            return db.Candidats.Where(predicate).ToList();
        }

        public Candidat Get(int id)
        {
            return db.Candidats.Find(id);
        }

        public IEnumerable<Candidat> GetAll()
        {
            return db.Candidats;
        }

        public void Update(Candidat item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
