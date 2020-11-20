using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMT.Models
{
    public class Dcard
    {
        public int ID { get; set; }
        [Required]
        
        
        public string CardNumber { get; set; }

        [Required]
        public int month { get; set; }

        [Required]
        public int year { get; set; }

        [Required]
        public int CVV {get;set;}

        [Required]
        public string mailid { get; set; }

        [Required]
        public int balance { get; set; }

    }
}
