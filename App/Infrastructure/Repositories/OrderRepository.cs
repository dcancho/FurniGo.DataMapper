using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.App.Domain.Repositories;
using FurniGo.DataMapper.Shared.Infrastructure.Configuration;
using FurniGo.DataMapper.Shared.Infrastructure.Repositories;
using MongoDB.Driver;

namespace FurniGo.DataMapper.App.Infrastructure.Repositories
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(AppDbContext dbContext) : base(dbContext)
		{ }

		public async Task<bool> UpdateStatusOrder(string id, string status)
		{
			var filter = Builders<Order>.Filter.Eq(e => e.Id, id);
			var update = Builders<Order>.Update.Set(e => e.Status, status);
			var result = await _context.Collection<Order>().UpdateOneAsync(filter, update);
			return result.ModifiedCount > 0;
		}

		public async Task<bool> AssignWorkshop(string id, string workshopId)
		{
			var filter = Builders<Order>.Filter.Eq(e => e.Id, id);
			var update = Builders<Order>.Update.Set(e => e.WorkshopId, workshopId);
			var result = await _context.Collection<Order>().UpdateOneAsync(filter, update);
			return result.ModifiedCount > 0;
		}

		public async Task<bool> UpdateDueDate(string id, DateOnly dueDate)
		{
			var filter = Builders<Order>.Filter.Eq(e => e.Id, id);
			var update = Builders<Order>.Update.Set(e => e.DueDate, dueDate);
			var result = await _context.Collection<Order>().UpdateOneAsync(filter, update);
			return result.ModifiedCount > 0;
		}

		public async Task<bool> UpdateBudget(string id, float budget)
		{
			var filter = Builders<Order>.Filter.Eq(e => e.Id, id);
			var update = Builders<Order>.Update.Set(e => e.Budget, budget);
			var result = await _context.Collection<Order>().UpdateOneAsync(filter, update);
			return result.ModifiedCount > 0;
		}

		public async Task<bool> UpdateDescription(string id, string description)
		{
			var filter = Builders<Order>.Filter.Eq(e => e.Id, id);
			var update = Builders<Order>.Update.Set(e => e.Description, description);
			var result = await _context.Collection<Order>().UpdateOneAsync(filter, update);
			return result.ModifiedCount > 0;
		}

		public async Task<bool> UpdateShippingAddress(string id, string shippingAddress)
		{
			var filter = Builders<Order>.Filter.Eq(e => e.Id, id);
			var update = Builders<Order>.Update.Set(e => e.ShippingAddress, shippingAddress);
			var result = await _context.Collection<Order>().UpdateOneAsync(filter, update);
			return result.ModifiedCount > 0;
		}
	}
}
