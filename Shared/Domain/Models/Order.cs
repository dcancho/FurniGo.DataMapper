using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	public class Order : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("customerId")]
		public string CustomerId { get; set; }
		[BsonElement("workshopId")]
		public string? WorkshopId { get; set; }
		[BsonElement("shippingAddress")]
		public string ShippingAddress { get; set; }
		[BsonElement("status")]
		public string Status { get; set; }
		[BsonElement("dueDate")]
		public DateOnly DueDate { get; set; }
		[BsonElement("budget")]
		public float Budget { get; set; }
		[BsonElement("description")]
		public string Description { get; set; }
	}
}
