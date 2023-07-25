using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public record CategoryDTO
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "Category Name is required")]
        public String? CategoryName { get; init; } = String.Empty;
    }
}
