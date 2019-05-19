using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class PollingStationRepository : IRepository<PollingStation>
    {
        private ElectionsContext db;

        public PollingStationRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(PollingStation item)
        {
            db.PollingStations.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.PollingStations.Find(id);
            if (item != null)
                db.PollingStations.Remove(item);
        }

        public IEnumerable<PollingStation> Find(Func<PollingStation, bool> predicate)
        {
            return db.PollingStations.Where(predicate).ToList();
        }

        public PollingStation Get(int id)
        {
            return db.PollingStations.Find(id);
        }

        public IEnumerable<PollingStation> GetAll()
        {
            return db.PollingStations;
        }

        public void Update(PollingStation item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
