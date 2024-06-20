using FruitableShop.Models;

namespace FruitableShop.Repository
{
    // ========== Facade ========== //
    public class ProductFacade
    {
        private readonly IRepository<Product> _productRepository;

        public ProductFacade(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> SearchProducts(string keyword)
        {
            return _productRepository.SearchByName(keyword);
        }

        public Product Detail(int id)
        {
            return _productRepository.FindById(id);
        }
    }
}
