using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TyreShop.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            // context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Opona Kleber 195/50/R15",
                    Description = "Klasa średnia",
                    Category = "osobowy",
                    Price = 225M
                },
                new Product
                {
                    Name = "Opona Michelin 225/45/R17",
                    Description = "Klasa premium",
                    Category = "osobowe",
                    Price = 485M
                },
                new Product
                {
                    Name = "Opona Dębica 195/55/R15",
                    Description = "Klasa średnia",
                    Category = "osobowe",
                    Price = 190M
                },
                new Product
                {
                    Name = "Opona Hankook 225/60/R17",
                    Description = "Klasa wyższa",
                    Category = "SUV",
                    Price = 590M
                },
                new Product
                {
                    Name = "Opona Hankook 215/70/R16",
                    Description = "Klasa wyższa",
                    Category = "SUV",
                    Price = 490M
                },
                new Product
                {
                    Name = "Opona Michelin 245/55/R18",
                    Description = "Klasa wyższa",
                    Category = "SUV",
                    Price = 7950M
                }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
