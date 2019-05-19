using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vybory.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public int IPN { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
        
        public Citizen Citizen { get; set; }
    }
}
