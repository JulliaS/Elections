using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Center { get; set; }
        
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public List<Citizen> Citizens { get; set; }
        public List<PollingStation> PollingStations { get; set; }
        public List<ChermanOfDistrict> ChermanOfDistricts { get; set; }

    }
}
