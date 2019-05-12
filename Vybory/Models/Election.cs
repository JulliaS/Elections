using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class Election
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int? TourId { get; set; }
        public Tour Tour { get; set; }

        public DateTime StartVote { get; set; }

        public DateTime EndVote { get; set; }

        public List<Citizen> Citizens { get; set; }
        public List<Candidat> Candidats { get; set; }
        public List<Vote> Votes { get; set; }
        public List<ChermanOfDistrict> ChermanOfDistricts { get; set; }
        public List<ChermanOfPollingStation> ChermanOfPollingStations { get; set; }
        public List<Observer> Observers { get; set; }
        public List<Complaint> Complaints { get; set; }
        public List<Appeal> Appeals { get; set; }
    }
}
