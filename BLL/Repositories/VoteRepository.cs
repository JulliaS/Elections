using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class VoteRepository : IRepository<Vote>
    {
        private ElectionsContext db;

        public VoteRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Vote item)
        {
            db.Votes.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Votes.Find(id);
            if (item != null)
                db.Votes.Remove(item);
        }

        public IEnumerable<Vote> Find(Func<Vote, bool> predicate)
        {
            return db.Votes.Where(predicate).ToList();
        }

        public Vote Get(int id)
        {
            return db.Votes.Find(id);
        }

        public IEnumerable<Vote> GetAll()
        {
            return db.Votes;
        }

        public void Update(Vote item)
        {
            db.Entry(item).State = EntityState.Modified; 
        }
    }
}
