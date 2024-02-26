using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.Shared.Domain.Models
{
	/// <summary>
	/// Entity that represents a media file in the system.
	/// </summary>
	public class Media : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		/// <summary>
		/// The title of the media file.
		/// </summary>
		[BsonElement("title")]
		public string Title { get; set; }
		/// <summary>
		/// Filename of the media file.
		/// </summary>
		[BsonElement("filename")]
		public string Filename { get; set; }
		/// <summary>
		/// Description of the media file.
		/// </summary>
		[BsonElement("description")]
		public string Description { get; set; }
		/// <summary>
		/// The user who uploaded the media file.
		/// </summary>
		[BsonElement("posterId")]
		public string PosterId { get; set; }
		/// <summary>
		/// Identifier of the content in the instance where the media file is stored as a binary.
		/// </summary>
		[BsonElement("contentId")]
		public string ContentId { get; set; }
		/// <summary>
		/// Size of the media file in bytes.
		/// </summary>
		[BsonElement("filesize")]
		public long FileSize { get; set; }
		/// <summary>
		/// Byte array of the media file. Is <c>null</c> if the media file is stored in a different instance and hasn't been retrieved yet.
		/// </summary>
		[BsonIgnore]
		public byte[]? File { get; set; }
	}
}
