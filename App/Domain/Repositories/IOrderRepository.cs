using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.App.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
			/// <summary>
			/// Update status of order manually.
			/// </summary>
			/// <param name="id"></param>
			/// <param name="status"></param>
			/// <returns></returns>
			Task<bool> UpdateStatusOrder(string id, string status);
			/// <summary>
			/// Assign a workshop to an order.
			/// </summary>
			/// <param name="id"></param>
			/// <param name="workshopId"></param>
			/// <returns></returns>
			Task<bool> AssignWorkshop(string id, string workshopId);
			/// <summary>
			/// Update due date of an order.
			/// </summary>
			/// <param name="id"></param>
			/// <param name="dueDate"></param>
			/// <returns></returns>
			Task<bool> UpdateDueDate(string id, DateOnly dueDate);
			/// <summary>
			/// Update budget of an order.
			/// </summary>
			/// <param name="id"></param>
			/// <param name="budget"></param>
			/// <returns></returns>
			Task<bool> UpdateBudget(string id, float budget);
			/// <summary>
			/// Update description of an order.
			/// </summary>
			/// <param name="id"></param>
			/// <param name="description"></param>
			/// <returns></returns>
			Task<bool> UpdateDescription(string id, string description);
			/// <summary>
			/// Update shipping address of an order.
			/// </summary>
			/// <param name="id"></param>
			/// <param name="shippingAddress"></param>
			/// <returns></returns>
			Task<bool> UpdateShippingAddress(string id, string shippingAddress);
    }
}
