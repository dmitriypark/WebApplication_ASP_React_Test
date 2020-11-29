using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_React_Test.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders;

        public void SaveForm (Order order)
        {
            if (order.orderId == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.FirstOrDefault(p => p.orderId == order.orderId);
                if (dbEntry != null)
                {
                    dbEntry.citySender = order.citySender;
                    dbEntry.addressSender = order.addressSender;
                    dbEntry.cityRecipient = order.cityRecipient;
                    dbEntry.addressRecipient = order.addressRecipient;
                    dbEntry.weight = order.weight;
                    dbEntry.dateTaken = order.dateTaken;
                }
            }
            context.SaveChanges();
        }

        public Order DeleteForm(int orderId)
        {
            Order dbEntry = context.Orders.FirstOrDefault(p => p.orderId == orderId);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
