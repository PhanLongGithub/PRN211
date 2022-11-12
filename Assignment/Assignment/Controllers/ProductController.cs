using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class ProductController : Controller
    {
        int numberInCart = 0;
        public IActionResult List()
        {
            using(var context = new FoodieDBContext())
            {
                numberInCart = context.Carts.Where(c => c.UserId == 1).Count();
                List<Product> products = context.Products.ToList();
                ViewBag.products = products;
                ViewBag.numberInCart = numberInCart;
                return View();
            }
        }
        public IActionResult AddToCart(int Id)
        {
            using (var context = new FoodieDBContext())
            {
                Product products = context.Products.FirstOrDefault(p => p.ProductId == Id);
                if(products.Quantity < 1)
                {
                    ViewBag.mess = "Out of Product";
                    return RedirectToAction("List");
                }
                Cart cart = new Cart(Id,1,1);
                context.Carts.Add(cart);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
