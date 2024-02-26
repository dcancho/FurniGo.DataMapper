using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.Shared.Domain.Repositories
{
	/// <summary>
	/// Interface for the user repository. It provides additional operations for the User entity still using CRUD based operations.
	/// </summary>
	public interface IUserRepository : IBaseRepository<User>
	{
	}
}