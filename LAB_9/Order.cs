using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_9.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int Amount { get; set; }

        public string OrderDate { get; set; }

        public string OrderTime { get; set; }

        public int Cust_ID { get; set; }

        public int P_ID { get; set; }
        [ForeignKey("Cust_ID")]
        public Customer Customer { get; set; }
        [ForeignKey("P_ID")]
        public Product Product { get; set; }
    }
}
