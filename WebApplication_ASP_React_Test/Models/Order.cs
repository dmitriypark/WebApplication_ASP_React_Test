using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_React_Test.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public string citySender { get; set; }
        public string addressSender { get; set; }
        public string cityRecipient {get;set;}
        
        public string addressRecipient {get;set;}

        public double weight { get; set; }

        public DateTime dateTaken { get; set; }
    }
}
