namespace Shoop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            // Create the Users
            var user = await this.userHelper.GetUserByEmailAsync("sevann.radhak@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Sevann",
                    LastName = "Radhak",
                    Email = "sevann.radhak@gmail.com",
                    UserName = "sevann.radhak@gmail.com",
                    PhoneNumber = "5491173627795"
                };

                var result = await this.userHelper.AddUserAsync(user, "sevann.radhak@gmail.com");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            // Create the Products
            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product", user);
                this.AddProduct("Second Product", user);
                this.AddProduct("Third Product", user);

                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvaliable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
