using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult List()
        {
            using(var context = new FoodieDBContext())
            {
                //string eId = Request.Form["orders.employeeid"];
                List<Category> categories = context.Categories.ToList();
                ViewBag.categories = categories;
            }
            return View();
        }

        public IActionResult Delete(int Id)
        {
            using(var context = new FoodieDBContext())
            {
                Category category = context.Categories.FirstOrDefault(c => c.CategoryId == Id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            Category category = new Category();
            using (var context = new FoodieDBContext())
            {
                category = context.Categories.FirstOrDefault(c => c.CategoryId == Id);
            }
            return View(category);
        }

        public IActionResult DoEdit(Category category)
        {
            string action = Request.Form["action"];
            if (action.Equals("Save",StringComparison.OrdinalIgnoreCase)){
                using (var context = new FoodieDBContext())
                {
                    Category category1 = context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
                    if (category1 != null)
                    {
                        category1.CategoryName = category.CategoryName;
                        category1.ImageUrl = category.ImageUrl;
                        category1.IsActive = category.IsActive;
                        category1.CreatedDate = DateTime.Now;
                    }
                    context.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
    }
}
