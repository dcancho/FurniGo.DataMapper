using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class OrderResourceMapper : IMapper<AppOrder, SaveOrderAppResource>
	{
		public AppOrder Map(SaveOrderAppResource toMap)
		{
			return new AppOrder
			{
				CustomerId = toMap.CustomerId,
				WorkshopId = toMap.WorkshopId,
				ShippingAddress = toMap.ShippingAddress,
				Status = toMap.Status,
				DueDate = toMap.DueDate,
				Budget = toMap.Budget,
				Description = toMap.Description
			};
		}

		public SaveOrderAppResource Map(AppOrder toMap)
		{
			return new SaveOrderAppResource
			{
				CustomerId = toMap.CustomerId,
				WorkshopId = toMap.WorkshopId,
				ShippingAddress = toMap.ShippingAddress,
				Status = toMap.Status,
				DueDate = toMap.DueDate,
				Budget = toMap.Budget,
				Description = toMap.Description
			};
		}
	}
}