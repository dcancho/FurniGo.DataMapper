using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.IAM.Domain.Models
{
	/// <summary>
	/// Represents an user in the IAM domain.
	/// </summary>
    public class IAMUser : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
				public string LastName { get; set; }
        public string Username { get; set; }
				public string Password { get; set; }
				public string Email { get; set; }
				public string PhoneNumber { get; set; }
				public string UserRole { get; set; }
				public string Address { get; set; }
    }
}