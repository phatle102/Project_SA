using FruitableShop.Models;

namespace FruitableShop.Repository
{
    public interface IUserRepository
    {
        public List<User> GetAllUser();
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(int userID);

        public User FindById(int id);
    }
}
