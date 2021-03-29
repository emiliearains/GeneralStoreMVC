using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreMVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransID { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime DateofTransaction { get; set; }
    }
}