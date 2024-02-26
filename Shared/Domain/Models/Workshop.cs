using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	/// <summary>
	/// Entity that represents a workshop in the system.
	/// </summary>
	public class Workshop : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		/// <summary>
		/// Name of the workshop.
		/// </summary>
		[BsonElement("name")]
		public string Name { get; set; }
		/// <summary>
		/// Description of the workshop.
		/// </summary>
		[BsonElement("description")]
		public string Description { get; set; }
		/// <summary>
		/// Address of the workshop.
		/// </summary>
		[BsonElement("address")]
		public string Address { get; set; }
		/// <summary>
		/// List of the ids of the users that are registered to the workshop as workers.
		/// </summary>
		[BsonElement("registeredUsers")]
		public List<string> RegisteredUsers { get; set; }
	}
}
