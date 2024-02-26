using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	/// <summary>
	/// Entity that represents an order in the system.
	/// </summary>
	public class Order : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		/// <summary>
		/// Identifier of the user who placed the order.
		/// </summary>
		[BsonElement("customerId")]
		public string CustomerId { get; set; }
		/// <summary>
		/// Identifier of the workshop that will fulfill the order. Might be <c>null</c> if the order is not yet assigned to a workshop.
		/// </summary>
		[BsonElement("workshopId")]
		public string? WorkshopId { get; set; }
		/// <summary>
		/// Address where the order will be shipped.
		/// </summary>
		[BsonElement("shippingAddress")]
		public string ShippingAddress { get; set; }
		/// <summary>
		/// Status of the order. Can be <c>Pending</c>, <c>Accepted</c>, <c>Rejected</c>, <c>InProcess</c>, <c>Ready</c>, <c>Delivered</c> or <c>Cancelled</c>.
		/// </summary>
		[BsonElement("status")]
		public string Status { get; set; }
		/// <summary>
		/// Due date of the order.
		/// </summary>
		[BsonElement("dueDate")]
		public DateOnly DueDate { get; set; }
		/// <summary>
		/// Budget of the order. Starts as a client defined value and then is adjusted to the budget proposed and accepted by the workshop.
		/// </summary>
		[BsonElement("budget")]
		public float Budget { get; set; }
		/// <summary>
		/// Description of the order.
		/// </summary>
		[BsonElement("description")]
		public string Description { get; set; }
	}
}
