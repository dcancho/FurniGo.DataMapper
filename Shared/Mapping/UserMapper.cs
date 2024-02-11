using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.Shared.Mapping
{
    public class UserMapper : IMapper<User, AppUser, SocialNetworkMapperUser>
    {
        public User MapBase(AppUser toMap, User baseObject)
        {
            return new User
            {
                Id = baseObject.Id,
                Username = toMap.Username,
                FirstName = toMap.Name.Split(' ')[0],
                LastName = toMap.Name.Split(' ')[1],
                PhoneNumber = baseObject.PhoneNumber,
                Email = baseObject.Email
            };
        }
        public User MapBase(SocialNetworkMapperUser toMap, User baseObject)
        {
            return new User
            {
                Id = baseObject.Id,
                Username = string.Empty,
                Password = string.Empty,
                FirstName = toMap.FirstName,
                LastName = toMap.LastName,
                PhoneNumber = baseObject.PhoneNumber,
                Email = toMap.Email
            };
        }

        public User MapDefault(AppUser toMap)
        {
            return new User
            {
                Id = toMap.Id,
                Username = toMap.Username,
                Password = string.Empty,
                FirstName = toMap.Name.Split(' ')[0],
                LastName = toMap.Name.Split(' ')[1],
                PhoneNumber = string.Empty,
                Email = string.Empty
            };
        }
        public User MapDefault(SocialNetworkMapperUser toMap)
        {
            throw new NotImplementedException();
        }

        public AppUser MapToType1(User toMap)
        {
            return new AppUser
            {
                Id = toMap.Id,
                Name = $"{toMap.FirstName} {toMap.LastName}",
                Username = toMap.Username
            };
        }
        public SocialNetworkMapperUser MapToType2(User toMap)
        {
            return new SocialNetworkMapperUser
            {
                Id = toMap.Id,
                FirstName = toMap.FirstName,
                LastName = toMap.LastName,
                Email = toMap.Email
            };
        }
    }
}
