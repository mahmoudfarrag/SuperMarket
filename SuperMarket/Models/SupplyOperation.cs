using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class SupplyOperation
    {
        public int Id { get; set; }


        [Required]
        public Supplier Supplier { get; set; }

        [Required]
        public Product Product { get; set; }

        public DateTime SupplayDate { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}