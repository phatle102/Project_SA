using Microsoft.AspNetCore.Mvc;

namespace StoreManagement.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
