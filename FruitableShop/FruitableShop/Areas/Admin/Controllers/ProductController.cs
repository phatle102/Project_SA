using FruitableShop.Models;
using FruitableShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IRepository<Product> _productRepository;
        private readonly ProductFacade _productFacade;
        private readonly SearchInvoker _searchInvoker;

        public ProductController(
            IRepository<Product> productRepository, 
            ProductFacade productFacade)
        {
            _productRepository = productRepository;
            _productFacade = productFacade;
            _searchInvoker = new SearchInvoker();
            _searchInvoker.RegisterCommand("SearchByName", new SearchProductByNameCommand(_productRepository));
        }
        public IActionResult Index()
        {
            List<Product> product = _productRepository.GetAll();
            return View(product);
        }

        [HttpGet]
        public ActionResult SearchProduct(string keyword)
        {
            /*List<Product> productList = _productSearchFacade.SearchProducts(keyword);*/
            List<Product> productList = _searchInvoker.ExecuteCommand("SearchByName", keyword);
            return View("Index", productList);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveAddProduct(Product product)
        {
            if (_productRepository.Create(product))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Product product = _productRepository.FindById(id);
            if (product != null)
            {
                return View(product);
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (_productRepository.Update(product))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            Product product = _productRepository.FindById(id);
            if (product != null)
            {
                return View(product);
            }
            return View();
        }
        public IActionResult ConfirmDelete(Product product)
        {
            if (_productRepository.Delete(product.Id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Product product = _productFacade.Detail(id);
            if (product != null)
            {
                return View(product);
            }
            return View();
        }
    }
}
