using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class AppOrderMapper : IMapper<Order, AppOrder>
	{
		public Order Map(AppOrder toMap)
		{
			return new Order
			{
				Id = toMap.Id,
				CustomerId = toMap.CustomerId,
				WorkshopId = toMap.WorkshopId,
				ShippingAddress = toMap.ShippingAddress,
				Status = toMap.Status,
				DueDate = toMap.DueDate,
				Budget = toMap.Budget,
				Description = toMap.Description
			};
		}

		public AppOrder Map(Order toMap)
		{
			return new AppOrder
			{
				Id = toMap.Id,
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