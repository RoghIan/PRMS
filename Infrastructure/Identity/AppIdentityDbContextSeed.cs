using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Rogh Ian",
                    Email = "roghiansawangen@gmail.com",
                    UserName = "roghiansawangen@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Rogh",
                        LastName = "Sawangen",
                        Street = "Valentina Street",
                        City = "Bayambang",
                        State = "Pangasinan",
                        Zipcode = "2423"
                    }
                };

                await userManager.CreateAsync(user, "123P@ssword");
            }
        }
    }
}
