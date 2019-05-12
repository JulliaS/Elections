using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vybory.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string Region { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public List<District> Districts { get; set; }
        public List<PollingStation> PollingStations { get; set; }
    }
}
