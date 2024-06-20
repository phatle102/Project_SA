using FruitableShop.Models;
using FruitableShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IRepository<Product> _productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            List<Product> product = _productRepository.GetAll();
            return View(product);
        }

        [HttpGet]
        public ActionResult SearchProduct(string keyword)
        {
            List<Product> productList = _productRepository.SearchByName(keyword);
            return View(productList);
        }


    }
}
