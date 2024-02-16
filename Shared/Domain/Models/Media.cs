using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
    public class Media : IEntity
    {
				[BsonId]
				[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
				[BsonElement("title")]
				public string Title { get; set; }
				[BsonElement("description")]
				public string Description { get; set; }
				[BsonElement("posterId")]
				public string PosterId { get; set; }
				[BsonElement("content")]
				public string ContentId { get; set; }
				/// <summary>
				/// File size in bytes
				/// </summary>
				[BsonElement("filesize")]
				public long FileSize { get; set; }
    }
}
