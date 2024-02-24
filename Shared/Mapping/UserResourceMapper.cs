using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class UserResourceMapper : IMapper<User, SaveUserResource>
	{
		public User Map(SaveUserResource source)
		{
			return new User
            {
				FirstName = source.FirstName,
				LastName = source.LastName,
				Username = source.Username,
				Password = source.Password,
				Email = source.Email,
				PhoneNumber = source.PhoneNumber ?? string.Empty
			};
		}

		public SaveUserResource Map(User source)
		{
			return new SaveUserResource
			{
				FirstName = source.FirstName,
				LastName = source.LastName,
				Username = source.Username,
				Password = source.Password,
				Email = source.Email,
				PhoneNumber = source.PhoneNumber
			};
		}
	}
}