using FruitableShop.Models;

namespace FruitableShop.Repository
{
    // ========== Command ========== //
    public class SearchProductByNameCommand : ISearchCommand
    {
        private readonly IRepository<Product> _productRepository;

        public SearchProductByNameCommand(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> Execute(string keyword)
        {
            return _productRepository.SearchByName(keyword);
        }
    }
}
