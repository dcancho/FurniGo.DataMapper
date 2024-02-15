using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	public class Workshop : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("name")]
		public string Name { get; set; }
		[BsonElement("description")]
		public string Description { get; set; }
		[BsonElement("address")]
		public string Address { get; set; }
		[BsonElement("registeredUsers")]
		public List<string> RegisteredUsers { get; set; }
	}
}
