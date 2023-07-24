﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public record UserDTOForCreation :UserDTO
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }
    }
}
