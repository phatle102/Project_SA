using FruitableShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
