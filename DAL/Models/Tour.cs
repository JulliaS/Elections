using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public List<Election> Elections { get; set; }
    }
}
