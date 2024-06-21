using FruitableShop.Models;

namespace FruitableShop.Repository
{
    // ========== Command ========== //
    public interface ISearchCommand
    {
        List<Product> Execute(string keyword);
    }
}
