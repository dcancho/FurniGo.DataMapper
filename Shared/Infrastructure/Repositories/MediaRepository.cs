using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Infrastructure.Configuration;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Shared.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of IMediaRepository for MongoDB.
    /// </summary>
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {

        private readonly GridFSBucket _gridFsBucket;

        public MediaRepository(AppDbContext dbContext) : base(dbContext)
        {
            _gridFsBucket = dbContext.gridFSBucket;
        }
        public async Task<string> StoreFileAsync(Stream fileStream, string fileName)
        {
            var fileId = await _gridFsBucket.UploadFromStreamAsync(fileName, fileStream);
            return fileId.ToString();
        }

        public async Task<Stream> GetFileAsync(string fileId)
        {
            var stream = new MemoryStream();
            await _gridFsBucket.DownloadToStreamAsync(ObjectId.Parse(fileId), stream);
            stream.Position = 0;
            return stream;
        }

        public new async Task<Media> GetById(string id)
        {
            var media = await base.GetById(id);
            if (media != null && media.Title != null)
            {
                using (var stream = await GetFileAsync(media.ContentId))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        media.File = memoryStream.ToArray();
                    }
                }
            }
            return media;
        }

        public new async Task Create(Media entity)
        {
            if (entity.File != null)
            {
                entity.ContentId = await StoreFileAsync(new MemoryStream(entity.File), entity.Filename);
            }
            await base.Create(entity);
        }

        public new async Task<IEnumerable<Media>> GetAll()
        {
            var medias = await base.GetAll();
            return medias;
        }

        public new async Task<Media> Update(Media entity)
        {
            if (entity.File != null)
            {
                entity.ContentId = await StoreFileAsync(new MemoryStream(entity.File), entity.Filename);
            }
            return await base.Update(entity);
        }

        public new async Task<Media> Delete(string id)
        {
            var media = await GetById(id);
            if (media != null)
            {
                await _gridFsBucket.DeleteAsync(ObjectId.Parse(media.ContentId));
            }
            return await base.Delete(id);
        }
    }

}
