using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> Users();
        Task<IdentityResult> CreateUser(UserDTOForCreation userDtoForCreation);
        Task<IdentityUser> GetOneUser(string username);
        Task<UserDTOForUpdate> GetOneUserForUpdate(string username);
        Task Update(UserDTOForUpdate  userDtoForUpdate);
        Task<IdentityResult> ResetPassword(ResetPasswordDTO reserPaswswordDto);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
