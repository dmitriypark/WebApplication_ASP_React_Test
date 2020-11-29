using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication_ASP_React_Test.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order { citySender = "Санкт-Петербург", addressSender = "Ленинградский проспект 44", cityRecipient = "Саратов",
                        addressRecipient = "Ленинградский проспект 12", weight = 2, dateTaken = DateTime.Now },
                    new Order { citySender = "Москва", addressSender = "Ленинградский проспект 44", cityRecipient = "Екатеринбург", 
                        addressRecipient = "Ленинградский проспект 12", weight = 2, dateTaken = DateTime.Now });                    
                context.SaveChanges();
            }
        }
    }
}
