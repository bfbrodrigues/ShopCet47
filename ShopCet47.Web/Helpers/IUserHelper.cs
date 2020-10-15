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
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);


        Task<IdentityResult> AddUserAsync(User user, string password);


        //A partir daqui utiliza-se a class Identity - Responsavel pela autenticação do login
        Task<SignInResult> LoginAsync(LoginViewModel model);


        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);


        Task<IdentityResult> ChangePasswordAsync(User user, string OldPassword, string NewPassword);
    }
}
