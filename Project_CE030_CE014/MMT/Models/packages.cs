using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMT.Models
{
    public class packages
    {
        public int PackagesID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Places { get; set; }

        [Required]
        
        public int Amount { get; set; }

        
        public int discount { get; set; }

        [Required]
        [StringLength(100)]
        public string Duration { get; set; }

        [Required]
        public string Facilities { get; set; }

        public string Description { get; set; }
    }
}
