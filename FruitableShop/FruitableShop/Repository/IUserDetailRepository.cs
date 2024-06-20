using FruitableShop.Models;

namespace FruitableShop.Repository
{
    // ========== Factory ========== //
    public interface IUserDetailRepository
    {
        string ObjName { get; set; }
        User FindById(int id);
        void ShowInformation(string message);
    }
}
