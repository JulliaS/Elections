using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ComplaintRepository : IRepository<Complaint>
    {
        private ElectionsContext db;

        public ComplaintRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Complaint item)
        {
            db.Complaints.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Complaints.Find(id);
            if (item != null)
                db.Complaints.Remove(item);
        }

        public IEnumerable<Complaint> Find(Func<Complaint, bool> predicate)
        {
            return db.Complaints.Where(predicate).ToList();
        }

        public Complaint Get(int id)
        {
            return db.Complaints.Find(id);
        }

        public IEnumerable<Complaint> GetAll()
        {
            return db.Complaints;
        }

        public void Update(Complaint item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
