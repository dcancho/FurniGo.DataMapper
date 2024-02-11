namespace FurniGo.DataMapper.Shared.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);
    }
}