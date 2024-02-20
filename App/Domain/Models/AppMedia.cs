using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.App.Domain.Models
{
	public class AppMedia : IEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public byte[] File { get; set; }
		public string ContentId { get; set; }
		public string Filename { get; set; }
	}
}