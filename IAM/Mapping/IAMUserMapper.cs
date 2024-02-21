using FurniGo.DataMapper.IAM.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.IAM.Mapping
{
	public class IAMUserMapper : IMapper<User, IAMUser>
	{
		public User Map(IAMUser toMap)
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

		public IAMUser Map(User toMap)
		{
			return new IAMUser
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