   using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;



        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await this._userHelper.CheckRoleAsync("Admin");
            await this._userHelper.CheckRoleAsync("Customer");

            var user = await _userHelper.GetUserByEmailAsync("bruno.baptista.rodrigues@formandos.cinel.pt");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Bruno",
                    LastName = "Rodrigues",
                    Email = "bruno.baptista.rodrigues@formandos.cinel.pt",
                    UserName = "bruno.baptista.rodrigues@formandos.cinel.pt",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not crate the user in seeder");
                }

                await this._userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isRole = await this._userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isRole)
            {
                await this._userHelper.AddUserToRoleAsync(user, "Admin");
            }

            if(!_context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Rato Mickey", user);
                this.AddProduct("iWatch Series 4", user);
                this.AddProduct("Ipad 2", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Entities.Product
            {
                Name = name,
                Price = _random.Next(1000),
                isAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
