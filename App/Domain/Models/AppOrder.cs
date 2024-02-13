using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.App.Domain.Models
{
	public class AppOrder : IEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string CustomerId { get; set; }
		public string? WorkshopId { get; set; }
		public string ShippingAddress { get; set; }
		public string Status { get; set; }
		public DateOnly DueDate { get; set; }
		public float Budget { get; set; }
		public string Description { get; set; }
	}
}