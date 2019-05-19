using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vybory.Models
{
    public class Citizen
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        
        public User User { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? PollingStationId { get; set; }
        public PollingStation PollingStation { get; set; }
        
        public int? ElectionId { get; set; }
        public Election Election { get; set; }

        //public int? VoteId { get; set; }
        //public Vote Vote { get; set; }

        public int? StatusId { get; set; }
        public Status Status { get; set; }

        public List<Vote> Votes { get; set; }
        public List<Candidat> Candidats { get; set; }
        public List<ChermanOfDistrict> ChermanOfDistricts { get; set; }
        public List<ChermanOfPollingStation> ChermanOfPollingStations { get; set; }
        public List<Observer> Observers { get; set; }
        public List <Appeal> Appeals { get; set; }
    }
}
