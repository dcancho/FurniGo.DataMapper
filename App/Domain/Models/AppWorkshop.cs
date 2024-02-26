using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.App.Domain.Models
{
	/// <summary>
	/// Represents a workshop in the App domain.
	/// </summary>
	public class AppWorkshop : IEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public List<string> RegisteredUsers { get; set; }
	}
}