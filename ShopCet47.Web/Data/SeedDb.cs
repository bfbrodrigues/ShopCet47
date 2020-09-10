using Microsoft.IdentityModel.Tokens;
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
        private Random _random;
        public SeedDb(DataContext context)
        {
            this._context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if(!_context.Products.Any())
            {
                this.AddProduct("iPhone X");
                this.AddProduct("Rato Mickey");
                this.AddProduct("iWatch Series 4");
                this.AddProduct("Ipad 2");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Entities.Product
            {
                Name = name,
                Price = _random.Next(1000),
                isAvailable = true,
                Stock = _random.Next(100)
            });
        }
    }
}
