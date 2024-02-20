using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.IAM.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;

namespace FurniGo.DataMapper.App.Mapping
{
	public class UserResourceMapper : IMapper<IAMUser, SaveUserResource>
	{
		public IAMUser Map(SaveUserResource toMap)
		{
			return new IAMUser
			{
				FirstName = toMap.FirstName,
				LastName = toMap.LastName,
				Username = toMap.Username,
				Password = toMap.Password,
				Email = toMap.Email,
				PhoneNumber = toMap.PhoneNumber ?? string.Empty
			};
		}

		public SaveUserResource Map(IAMUser toMap)
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