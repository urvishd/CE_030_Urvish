using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Models
{
    public class Booking
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        [Required]
        public string PackageName { get; set; }

      
        [Required]
        public int NumberofPersons { get; set; }
        [Required]
        public string JourneyDate { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Amount { get; set; }

        public string status { get; set; }

       
    }
}
