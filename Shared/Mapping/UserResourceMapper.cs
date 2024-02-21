using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.IAM.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class UserResourceMapper : IMapper<User, SaveUserResource>
	{
		public User Map(SaveUserResource toMap)
		{
			return new User
            {
				FirstName = toMap.FirstName,
				LastName = toMap.LastName,
				Username = toMap.Username,
				Password = toMap.Password,
				Email = toMap.Email,
				PhoneNumber = toMap.PhoneNumber ?? string.Empty
			};
		}

		public SaveUserResource Map(User toMap)
		{
			return new SaveUserResource
			{
				FirstName = toMap.FirstName,
				LastName = toMap.LastName,
				Username = toMap.Username,
				Password = toMap.Password,
				Email = toMap.Email,
				PhoneNumber = toMap.PhoneNumber
			};
		}
	}
}