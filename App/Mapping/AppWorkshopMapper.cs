using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class AppWorkshopMapper : IMapper<Workshop, AppWorkshop>
	{
		public Workshop Map(AppWorkshop toMap)
		{
			return new Workshop
			{
				Id = toMap.Id,
				Name = toMap.Name,
				Description = toMap.Description,
				Address = toMap.Address,
				RegisteredUsers = toMap.RegisteredUsers
			};
		}

		public AppWorkshop Map(Workshop toMap)
		{
			return new AppWorkshop
			{
				Id = toMap.Id,
				Name = toMap.Name,
				Description = toMap.Description,
				Address = toMap.Address,
				RegisteredUsers = toMap.RegisteredUsers
			};
		}
	}
}