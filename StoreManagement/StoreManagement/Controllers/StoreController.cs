using Microsoft.AspNetCore.Mvc;
using StoreManagement.Models;

namespace StoreManagement.Controllers
{
    public class StoreController : Controller
    {
        private FruitableStoreContext _ctx;

        public StoreController(FruitableStoreContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
