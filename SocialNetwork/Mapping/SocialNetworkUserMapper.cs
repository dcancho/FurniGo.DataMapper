using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.SocialNetwork.Domain.Models;

namespace FurniGo.DataMapper.SocialNetwork.Mapping
{
	public class SocialNetworkUserMapper : IMapper<User, SocialNetworkUser>
	{
		public User Map(SocialNetworkUser toMap)
		{
			return new User
			{
				Id = toMap.Id,
				FirstName = toMap.FirstName,
				LastName = toMap.LastName,
			};
		}

		public SocialNetworkUser Map(User toMap)
		{
			return new SocialNetworkUser
			{
				Id = toMap.Id,
				FirstName = toMap.FirstName,
				LastName = toMap.LastName
			};
		}
	}
}
