using FruitableShop.Models;

namespace FruitableShop.Repository
{
    public class UserRepository : IUserRepository
    {
        private FruitableStoreContext _ctx;
        public UserRepository(FruitableStoreContext ctx)
        {
            _ctx = ctx;
        }

        public bool Create(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(int userID)
        {
            User u = _ctx.Users.FirstOrDefault(x => x.Id == userID);
            if (u != null)
            {
                _ctx.Users.Remove(u);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public User FindById(int id)
        {
            return _ctx.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> GetAllUser()
        {
            return _ctx.Users.ToList();
        }

        public bool Update(User user)
        {
            User u = _ctx.Users.FirstOrDefault(x => x.Id == user.Id);
            if (u != null)
            {
                _ctx.Entry(u).CurrentValues.SetValues(user);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
