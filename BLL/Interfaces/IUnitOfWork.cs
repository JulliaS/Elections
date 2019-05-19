using System;
using Vybory.Models;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Address> Addresses { get; }
        IRepository<Appeal> Appeals { get; }
        IRepository<AppealType> AppealTypes { get; }
        IRepository<Candidat> Candidats { get; }
        IRepository<ChermanOfDistrict> ChermanOfDistricts { get; }
        IRepository<ChermanOfPollingStation> ChermanOfPollingStations { get; }
        IRepository<Citizen> Citizens { get; }
        IRepository<Complaint> Complaints { get; }
        IRepository<ComplaintType> ComplaintTypes { get; }
        IRepository<District> Districts { get; }
        IRepository<Election> Elections { get; }
        IRepository<Observer> Observers { get; }
        IRepository<PollingStation> PollingStations { get; }
        IRepository<Role> Roles { get; }
        IRepository<Status> Statuses { get; }
        IRepository<Tour> Tours { get; }
        IRepository<User> Users { get; }
        IRepository<Vote> Votes { get; }
        void Save();
    }
}
