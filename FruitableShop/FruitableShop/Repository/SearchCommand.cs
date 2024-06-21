using FruitableShop.Models;

namespace FruitableShop.Repository
{
    // ========== Command ========== //
    public class SearchCommand : ISearchCommand
    {
        private readonly IRepository<Product> _productRepository;

        public SearchCommand(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> SearchByProductName(string keyword)
        {
            return _productRepository.SearchByName(keyword);
        }
    }
}
