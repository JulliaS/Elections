using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        public int? ElectionId { get; set; }
        public Election Election { get; set; }

        public int? PollingStationId { get; set; }
        public PollingStation PollingStation { get; set; }

        public int? ObserverId { get; set; }
        public Observer Observer { get; set; }

        public int? ComplaintTypeId { get; set; }
        public ComplaintType ComplaintType { get; set; }

        public string Text { get; set; }
    }
}
