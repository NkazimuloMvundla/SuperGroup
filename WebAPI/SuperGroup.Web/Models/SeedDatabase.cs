using Microsoft.EntityFrameworkCore;
using SuperGroup.Data;
using SuperGroup.Data.Models;
using System.Linq;

namespace SuperGroup.Web.Models
{
    public class SeedData
    {
        public static void SeedDatabase(SuperGroupDBContext context)
        {
            context.Database.Migrate();

            if (context.Products.Count() == 0)
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Price = 275,
                    },
                     new Product
                     {
                         Name = "Lifejacket",
                         Description = "Protective and fashionable",
                         Price = 48.95m,
                     },
                     new Product
                     {
                         Name = "Soccer Ball",
                         Description = "FIFA-approved size and weight",
                         Price = 19.50m,
                     },
                     new Product
                     {
                         Name = "Corner Flags",
                         Description = "Give your pitch a professional touch",
                         Price = 34.95m,
                     },
                     new Product
                     {
                         Name = "Stadium",
                         Description = "Flat-packed 35,000-seat stadium",
                         Price = 79500,
                     },
                     new Product
                     {
                         Name = "Thinking Cap",
                         Description = "Improve brain efficiency by 75%",
                         Price = 16,
                     },
                     new Product
                     {
                         Name = "Unsteady Chair",
                         Description = "Secretly give your opponent a disadvantage",
                         Price = 29.95m,
                     },
                     new Product
                     {
                         Name = "Human Chess Board",
                         Description = "A fun game for the family",
                         Price = 75,
                     },
                     new Product
                     {
                         Name = "Bling-Bling King",
                         Description = "Gold-plated, diamond-studded King",
                         Price = 1200,
                     });
                context.SaveChanges();
            }
        }
    }
}