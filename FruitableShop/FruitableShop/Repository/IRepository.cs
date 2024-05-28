namespace FruitableShop.Repository
{
    public interface IRepository<T> 
    {
        // ========== Adapter Pattern ========== //
        List<T> GetAll();
        List<T> SearchByName(string keyword);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);


        T FindById(int id);
    }
}