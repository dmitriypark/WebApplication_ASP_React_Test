using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_React_Test.Models
{
    public interface IOrderRepository
    {
        IQueryable <Order> Orders { get; }

        void SaveForm(Order form);

        Order DeleteForm(int formId);
    }
}
