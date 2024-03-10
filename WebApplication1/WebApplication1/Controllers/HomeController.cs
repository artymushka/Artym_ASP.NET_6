using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user.Age >= 16)
            {
                return RedirectToAction("OrderProducts", "Home", new { quantity = user.Age });
            }
            else
            {
                return Content("Ви молодші за 16 років");
            }
        }

        [HttpGet] // Додайте атрибут HttpGet
        public IActionResult OrderProducts(int quantity)
        {
            ViewBag.Quantity = quantity;
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmOrder(Product product)
        {
            // Обробляйте дані про замовлені товари тут
            return View("OrderConfirmation", product);
        }
    }
}

