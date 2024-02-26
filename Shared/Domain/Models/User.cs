using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	/// <summary>
	/// Entity that represents a user in the system.
	/// </summary>
	public class User : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		/// <summary>
		/// Username of the user.
		/// </summary>
		[BsonElement("username")]
		public string Username { get; set; }
		/// <summary>
		/// Hashed password of the user.
		/// </summary>
		[BsonElement("password")]
		public string Password { get; set; }
		/// <summary>
		/// First name of the user.
		/// </summary>
		[BsonElement("firstName")]
		public string FirstName { get; set; }
		/// <summary>
		/// Last name of the user.
		/// </summary>
		[BsonElement("lastName")]
		public string LastName { get; set; }
		/// <summary>
		/// Phone number of the user.
		/// </summary>
		[BsonElement("phoneNumber")]
		public string PhoneNumber { get; set; }
		/// <summary>
		/// Email of the user.
		/// </summary>
		[BsonElement("email")]
		public string Email { get; set; }
		/// <summary>
		/// Role of the user.
		/// </summary>
		[BsonElement("userRole")]
		public string UserRole { get; set; }
		/// <summary>
		/// Address of the user.
		/// </summary>
		[BsonElement("address")]
		public string Address { get; set; }
	}
}
