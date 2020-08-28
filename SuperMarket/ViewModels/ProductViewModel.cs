using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperMarket.Models;

namespace SuperMarket.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}