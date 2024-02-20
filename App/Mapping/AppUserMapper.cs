using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class AppUserMapper : IMapper<User, AppUser>
	{
		public User Map(AppUser toMap)
		{
			return new User
			{
				Id = toMap.Id,
				Username = toMap.Username,
				FirstName = toMap.FirstName,
				LastName = toMap.LastName,
				UserRole = toMap.UserRole,
				Address = toMap.Address
			};
		}

		public AppUser Map(User toMap)
		{
			return new AppUser
			{
				Id = toMap.Id,
				Username = toMap.Username,
				FirstName = toMap.FirstName,
				LastName = toMap.LastName,
				UserRole = toMap.UserRole,
				Address = toMap.Address
			};
		}
	}
}
