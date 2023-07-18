using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Product Name is required" )]
        public String? ProductName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public String? Summary { get; set; } =String.Empty;
        public String? ImageUrl { get; set; }


        public int? CategoryId { get; set; } 
        public Category? Category { get; set; }
    }
}
