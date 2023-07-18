using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public record ProductDTO 
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "Product Name is required")]
        public String? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }


        public int? CategoryId { get; init; }  //Foreign Key
    }
}
