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
                decimal totalPrice = 0;
                String orderNo = context.Orders.Count().ToString();
                List<Cart> carts = context.Carts.Where(c => c.UserId == Id).ToList();
                List<Payment> payments = context.Payments.Distinct().ToList();
                foreach (Cart cart in carts)
                {
                    Product product = context.Products.FirstOrDefault(p => p.ProductId == cart.ProductId);
                    cart.Product = product;
                    totalPrice += decimal.Parse(cart.Product.Price.ToString());
                }
                ViewBag.totalPrice = totalPrice;
                ViewBag.cart = carts;
                ViewBag.payments = payments;
                ViewBag.userID = Id;
                return View();
            }
        }

        public IActionResult CreateOrder()
        {
            string action = Request.Form["action"];
            string raw_userId = Request.Form["userID"];
            string raw_paymentId = Request.Form["pay"];
            int userId = Int32.Parse(raw_userId);
            int paymentId = Int32.Parse(raw_paymentId);
            using(var context = new FoodieDBContext())
            {
                int orderNumber = context.Orders.Count() + 1;
                String orderNo = orderNumber.ToString();

                List<Cart> carts = context.Carts.Where(c => c.UserId == userId).ToList();
                foreach (Cart cart in carts)
                {
                    Order order = new Order();
                    Product product = context.Products.FirstOrDefault(p => p.ProductId == cart.ProductId);
                    order.ProductId = product.ProductId;
                    order.OrderNo = orderNo;
                    order.Quantity = cart.Quantity;
                    order.UserId = userId;
                    order.Status = "Process";
                    order.PaymentId = paymentId;
                    order.OrderDate = DateTime.Now;
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                foreach (Cart cart in carts)
                {
                    context.Carts.Remove(cart);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult List()
        {
            using(var context = new FoodieDBContext())
            {
                List<Order> orders = context.Orders.ToList();
                ViewBag.orders = orders;
            }
            return View();
        }
    }
}
