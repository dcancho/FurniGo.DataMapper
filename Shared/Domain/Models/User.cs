using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	public class User : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("username")]
		public string Username { get; set; }
		[BsonElement("password")]
		public string Password { get; set; }
		[BsonElement("firstName")]
		public string FirstName { get; set; }
		[BsonElement("lastName")]
		public string LastName { get; set; }
		[BsonElement("phoneNumber")]
		public string PhoneNumber { get; set; }
		[BsonElement("email")]
		public string Email { get; set; }
		[BsonElement("userRole")]
		public string UserRole { get; set; }
		[BsonElement("address")]
		public string Address { get; set; }
	}
}
