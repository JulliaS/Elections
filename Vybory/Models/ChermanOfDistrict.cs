using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class ChermanOfDistrict
    {
        [Key]
        public int Id { get; set; }

        public int? ElectionId { get; set; }
        public Election Election { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}
