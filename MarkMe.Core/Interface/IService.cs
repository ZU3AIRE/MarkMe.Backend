namespace MarkMe.Core.Interface
{
    public interface IService<T> where T : class
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(int id, T updatedObj);
        Task Delete(int id);
        Task<T> Add(T obj);
    }
}
