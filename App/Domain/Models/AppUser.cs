using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.App.Domain.Models
{
	/// <summary>
	/// Represents an user in the App domain.
	/// </summary>
    public class AppUser : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
				public string LastName { get; set; }
        public string Username { get; set; }
				public string Address { get; set; }
				public string UserRole { get; set; }
    }
}