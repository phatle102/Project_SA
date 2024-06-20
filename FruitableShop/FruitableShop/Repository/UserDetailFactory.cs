namespace FruitableShop.Repository
{
    // ========== Factory ========== //
    public abstract class UserDetailFactory
    {
        public abstract IUserDetailRepository CreateUserDetailRepository();
    }
    public class ConcreteUserDetailFactory : UserDetailFactory
    {
        public override IUserDetailRepository CreateUserDetailRepository()
        {
            return new UserDetailRepository();
        }
    }
}
