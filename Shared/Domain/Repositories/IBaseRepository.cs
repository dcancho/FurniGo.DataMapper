namespace FurniGo.DataMapper.Shared.Domain.Repositories
{
	/// <summary>
	/// Interface for a generic repository. It provides basic CRUD operations for the <typeparamref name="T"/> entity.
	/// </summary>
	/// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
			/// <summary>
			/// Gets all the entities of type <typeparamref name="T"/> from the database.
			/// </summary>
			/// <returns> A <c>Task</c> that represents the asynchronous operation. The task result contains a collection of <typeparamref name="T"/> entities.</returns>
        Task<IEnumerable<T>> GetAll();
				/// <summary>
				/// Gets the entity of type <typeparamref name="T"/> with the specified <paramref name="id"/> from the database.
				/// </summary>
				/// <param name="id"></param>
				/// <returns>
				/// A <c>Task</c> that represents the asynchronous operation. The task result contains the <typeparamref name="T"/> entity with the specified <paramref name="id"/>.
				/// </returns>
        Task<T> GetById(string id);
				/// <summary>
				/// Creates a new entity of type <typeparamref name="T"/> in the database.
				/// </summary>
				/// <param name="entity"></param>
				/// <returns>
				/// A <c>Task</c> that represents the asynchronous operation.
				/// </returns>
        Task Create(T entity);
				/// <summary>
				/// Updates the entity of type <typeparamref name="T"/> in the database.
				/// </summary>
				/// <param name="entity"></param>
				/// <returns>
				/// A <c>Task</c> that represents the asynchronous operation. The task result contains the updated <typeparamref name="T"/> entity.
				/// </returns>
        Task<T> Update(T entity);
				/// <summary>
				/// Deletes the entity of type <typeparamref name="T"/> with the specified <paramref name="id"/> from the database.
				/// </summary>
				/// <param name="id"></param>
				/// <returns>
				/// A <c>Task</c> that represents the asynchronous operation. The task result contains the deleted <typeparamref name="T"/> entity.
				/// </returns>
        Task<T> Delete(string id);
    }
}