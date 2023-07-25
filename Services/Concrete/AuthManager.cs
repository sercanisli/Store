using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(UserDTOForCreation userDtoForCreation)
        {
            var user = _mapper.Map<IdentityUser>(userDtoForCreation);
            var result = await _userManager.CreateAsync(user, userDtoForCreation.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User could not be created.");
            }

            if (userDtoForCreation.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDtoForCreation.Roles);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with roles");
                }
            }
            return result;
        }

        public async Task<IdentityResult> DeleteOneUser(string userName)
        {
            var user = await GetOneUser(userName);
            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<IdentityUser> GetOneUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return user;
            }
            throw new Exception("User could not be found");
        }

        public async Task<UserDTOForUpdate> GetOneUserForUpdate(string username)
        {
            var user = await GetOneUser(username);
            var userDtoForUpdate = _mapper.Map<UserDTOForUpdate>(user);
            userDtoForUpdate.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
            userDtoForUpdate.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return userDtoForUpdate;
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDTO resetPasswordDto)
        {
            if (resetPasswordDto.ConfirmPassword == resetPasswordDto.Password)
            {
                var user = await GetOneUser(resetPasswordDto.UserName);
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, resetPasswordDto.Password);
                return result;
            }
            return null;
        }

        public async Task Update(UserDTOForUpdate userDtoForUpdate)
        {
            var user = await GetOneUser(userDtoForUpdate.UserName);
            user.PhoneNumber = userDtoForUpdate.PhoneNumber;
            user.Email = userDtoForUpdate.Email;

            var result = await _userManager.UpdateAsync(user);
            if (userDtoForUpdate.Roles.Count > 0)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
                var r2 = await _userManager.AddToRolesAsync(user, userDtoForUpdate.Roles);
            }
            return;
        }

        public IEnumerable<IdentityUser> Users()
        {
            return _userManager.Users.ToList();
        }
    }
}
