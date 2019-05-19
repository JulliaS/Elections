using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vybory;
using Vybory.Models;

namespace BLL.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private ElectionsContext db;

        public AddressRepository(ElectionsContext context)
        {
            db = context;
        }

        public void Create(Address item)
        {
            db.Addresses.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Addresses.Find(id);
            if (item != null)
                db.Addresses.Remove(item);
        }

        public IEnumerable<Address> Find(Func<Address, bool> predicate)
        {
            return db.Addresses.Where(predicate).ToList();
        }

        public Address Get(int id)
        {
            return db.Addresses.Find(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return db.Addresses;
        }

        public void Update(Address item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
