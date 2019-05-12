using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class PollingStation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public List<Citizen> Citizens { get; set; }
        public List<Vote> Votes { get; set; }
        public List<ChermanOfPollingStation> ChermanOfPollingStations { get; set; }
        public List<Observer> Observers { get; set; }
        public List<Complaint> Complaints { get; set; }
        public List<Appeal> Appeals { get; set; }
    }
}
