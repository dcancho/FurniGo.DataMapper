using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.SocialNetwork.Domain.Models
{
	/// <summary>
	/// User entity for the Social Network domain.
	/// </summary>
	public class SocialNetworkUser : IEntity
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		/// <summary>
		/// User's first name.
		/// </summary>
		public string FirstName { get; set; }
		/// <summary>
		/// User's last name.
		/// </summary>
		public string LastName { get; set; }
		/// <summary>
		/// Email of the user.
		/// </summary>
		public string Email { get; set; }
	}
}