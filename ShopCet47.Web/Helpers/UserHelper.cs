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

        public UserHelper(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }



        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
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
    }
}
