using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Infrastructure.Configuration;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Shared.Infrastructure.Repositories
{
	/// <summary>
	/// Implementation of IUserRepository for MongoDB.
	/// </summary>
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}
