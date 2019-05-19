using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ChermanOfPollingStationRepository : IRepository<ChermanOfPollingStation>
    {
        private ElectionsContext db;

        public ChermanOfPollingStationRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(ChermanOfPollingStation item)
        {
            db.ChermanOfPollingStations.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.ChermanOfPollingStations.Find(id);
            if (item != null)
                db.ChermanOfPollingStations.Remove(item);
        }

        public IEnumerable<ChermanOfPollingStation> Find(Func<ChermanOfPollingStation, bool> predicate)
        {
            return db.ChermanOfPollingStations.Where(predicate).ToList();
        }

        public ChermanOfPollingStation Get(int id)
        {
            return db.ChermanOfPollingStations.Find(id);
        }

        public IEnumerable<ChermanOfPollingStation> GetAll()
        {
            return db.ChermanOfPollingStations;
        }

        public void Update(ChermanOfPollingStation item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
