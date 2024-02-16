using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Mapping;

namespace FurniGo.DataMapper.App.Mapping
{
	public class WorkshopResourceMapper : IMapper<AppWorkshop, SaveWorkshopAppResource>
	{
		public AppWorkshop Map(SaveWorkshopAppResource toMap)
		{
			return new AppWorkshop
			{
				Name = toMap.Name,
				Description = toMap.Description,
				Address = toMap.Address,
				RegisteredUsers = []
			};
		}

		public SaveWorkshopAppResource Map(AppWorkshop toMap)
		{
			return new SaveWorkshopAppResource
			{
				Name = toMap.Name,
				Description = toMap.Description,
				Address = toMap.Address
			};
		}
	}
}