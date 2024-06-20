using FruitableShop.Models;

namespace FruitableShop.Repository
{
    public interface ISearchCommand
    {
        List<Product> Execute(string keyword);
    }
}
