using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(UserManager<User> UserManager, 
            SignInManager<User> SignInManager, 
            RoleManager<IdentityRole> RoleManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _roleManager = RoleManager;

        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await this._userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string OldPassword, string NewPassword)
        {
            return await this._userManager.ChangeEmailAsync(user, OldPassword, NewPassword);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await this._roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await this._roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }

            
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await this._userManager.IsInRoleAsync(user, "Admin");
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe, false); //indica se houve sign in ou nao
        }

        public async Task LogoutAsync()
        {
            await this._signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await this._userManager.UpdateAsync(user);
        }
    }
}
