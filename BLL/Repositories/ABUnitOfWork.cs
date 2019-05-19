using System;
using System.Collections.Generic;
using Vybory;
using Vybory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class ABUnitOfWork : IUnitOfWork
    {
        private ElectionsContext db;
        private AddressRepository addressRepository;
        private AppealRepository appealRepository;
        private AppealTypeRepository appealTypeRepository;
        private CandidatRepository candidatRepository;
        private ChermanOfDistrictRepository chermanOfDistrictRepository;
        private ChermanOfPollingStationRepository chermanOfPollingStationRepository;
        private CitizenRepository citizenRepository;
        private ComplaintRepository complaintRepository;
        private ComplaintTypeRepository complaintTypeRepository;
        private DistrictRepository districtRepository;
        private ElectionRepository electionRepository;
        private ObserverRepository observerRepository;
        private PollingStationRepository pollingStationRepository;
        private RoleRepository roleRepository;
        private StatusRepository statusRepository;
        private TourRepository tourRepository;
        private UserRepository userRepository;
        private VoteRepository voteRepository;

        public ABUnitOfWork(ElectionsContext context)
        {
            db = context;
        }

        public IRepository<Address> Addresses
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepository(db);
                return addressRepository;
            }
        }

        public IRepository<Appeal> Appeals
        {
            get
            {
                if (appealRepository == null)
                    appealRepository = new AppealRepository(db);
                return appealRepository;
            }
        }

        public IRepository<AppealType> AppealTypes
        {
            get
            {
                if (appealTypeRepository == null)
                    appealTypeRepository = new AppealTypeRepository(db);
                return appealTypeRepository;
            }
        }

        public IRepository<Candidat> Candidats
        {
            get
            {
                if (candidatRepository == null)
                    candidatRepository = new CandidatRepository(db);
                return candidatRepository;
            }
        }

        public IRepository<ChermanOfDistrict> ChermanOfDistricts
        {
            get
            {
                if (chermanOfDistrictRepository == null)
                    chermanOfDistrictRepository = new ChermanOfDistrictRepository(db);
                return chermanOfDistrictRepository;
            }
        }

        public IRepository<ChermanOfPollingStation> ChermanOfPollingStations
        {
            get
            {
                if (chermanOfPollingStationRepository == null)
                    chermanOfPollingStationRepository = new ChermanOfPollingStationRepository(db);
                return chermanOfPollingStationRepository;
            }
        }

        public IRepository<Citizen> Citizens
        {
            get
            {
                if (citizenRepository == null)
                    citizenRepository = new CitizenRepository(db);
                return citizenRepository;
            }
        }

        public IRepository<Complaint> Complaints
        {
            get
            {
                if (complaintRepository == null)
                    complaintRepository = new ComplaintRepository(db);
                return complaintRepository;
            }
        }

        public IRepository<ComplaintType> ComplaintTypes
        {
            get
            {
                if (complaintTypeRepository == null)
                    complaintTypeRepository = new ComplaintTypeRepository(db);
                return complaintTypeRepository;
            }
        }

        public IRepository<District> Districts
        {
            get
            {
                if (districtRepository == null)
                    districtRepository = new DistrictRepository(db);
                return districtRepository;
            }
        }

        public IRepository<Election> Elections
        {
            get
            {
                if (electionRepository == null)
                    electionRepository = new ElectionRepository(db);
                return electionRepository;
            }
        }

        public IRepository<Observer> Observers
        {
            get
            {
                if (observerRepository == null)
                    observerRepository = new ObserverRepository(db);
                return observerRepository;
            }
        }

        public IRepository<PollingStation> PollingStations
        {
            get
            {
                if (pollingStationRepository == null)
                    pollingStationRepository = new PollingStationRepository(db);
                return pollingStationRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }

        public IRepository<Tour> Tours
        {
            get
            {
                if (tourRepository == null)
                    tourRepository = new TourRepository(db);
                return tourRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                if (voteRepository == null)
                    voteRepository = new VoteRepository(db);
                return voteRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
