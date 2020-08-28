using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Dtos
{
    public class SupplyOperationDto
    {
        [Display(Name ="Suppliers")]
        public int SupplierId{ get; set; }

        [Display(Name = "Products")]
        public int ProductId { get; set; }

        [Display(Name = "Date")]
        public DateTime SupplayDate { get; set; }

       
        public int Quantity { get; set; }
    }
}