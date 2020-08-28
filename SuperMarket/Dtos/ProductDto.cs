using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        public bool? isDeleted { get; set; }

        
        public int CategoryId { get; set; }
    }
}