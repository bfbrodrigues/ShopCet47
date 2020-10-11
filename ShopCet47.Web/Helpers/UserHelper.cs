using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
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

        public UserHelper(UserManager<User> UserManager)
        {
            _userManager = UserManager;
        }


        public async Task<IdentityResult> AddUserAsync(User user, string  password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        
        
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
