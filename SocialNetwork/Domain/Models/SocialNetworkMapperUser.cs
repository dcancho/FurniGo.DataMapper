using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace FurniGo.DataMapper.SocialNetwork.Domain.Models
{
    public class SocialNetworkMapperUser : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}