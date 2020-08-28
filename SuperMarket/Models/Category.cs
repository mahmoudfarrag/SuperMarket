using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class Category
    {
       
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool? isDeleted { get; set; }
    }
}