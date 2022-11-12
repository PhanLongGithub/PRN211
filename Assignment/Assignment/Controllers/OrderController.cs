using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListOfOrder(int Id)
        {
            using (var context = new FoodieDBContext())
            {
                String orderNo = context.Orders.Count().ToString();
                Cart cart = context.Carts.FirstOrDefault(c => c.UserId == Id);
                List<Product> products = context.Products.Where(p => p.ProductId == cart.ProductId).ToList();
                foreach (Product product in products)
                {

                }
                List<Order> orders = context.Orders.Where(o => o.UserId == Id)
            }
        }
    }
}
