using FruitableShop.Models;

namespace FruitableShop.Repository
{
    // ========== Command ========== //
    public interface ISearchCommand
    {
        List<Product> SearchByProductName(string keyword);
    }
}
