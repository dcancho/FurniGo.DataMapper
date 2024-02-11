using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.App.Domain.Repositories;
using FurniGo.DataMapper.Shared.Infrastructure.Configuration;
using FurniGo.DataMapper.Shared.Infrastructure.Repositories;

namespace FurniGo.DataMapper.App.Infrastructure.Repositories
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        public MediaRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }

}
