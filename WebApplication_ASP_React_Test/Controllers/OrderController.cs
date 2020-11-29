using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_React_Test.Models;


namespace WebApplication_ASP_React_Test.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;

        public OrderController(IOrderRepository repo)
        {
            repository = repo;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable <Order> Get()
        {
            return repository.Orders;
        }

        public ViewResult Index() => View();
               
        public ViewResult Form()
        {
            return View();
        }

        [Route("api/[controller]")]        
        [HttpPost]
        public IActionResult Post(Order order)
        {
            repository.SaveForm(order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order form = repository.Orders.FirstOrDefault(f => f.orderId == id);
            if (form == null)
            {
                return NotFound();
            }
            repository.DeleteForm(id);
            return Ok(form);
        }

    }
}
