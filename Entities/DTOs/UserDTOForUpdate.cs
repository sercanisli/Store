﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public record UserDTOForUpdate:UserDTO
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}
