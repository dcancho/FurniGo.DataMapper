using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Infrastructure.Configuration;
using MongoDB.Driver;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Shared.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of IMediaRepository for MongoDB.
    /// </summary>
    public class WorkshopRepository : BaseRepository<Workshop>, IWorkshopRepository
    {
        public WorkshopRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddNewWorker(string id, string workerId)
        {
            var filter = Builders<Workshop>.Filter.Eq(e => e.Id, id);
            var update = Builders<Workshop>.Update.AddToSet(e => e.RegisteredUsers, workerId);
            var result = await _context.Collection<Workshop>().UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> ChangeAddress(string id, string address)
        {
            var filter = Builders<Workshop>.Filter.Eq(e => e.Id, id);
            var update = Builders<Workshop>.Update.Set(e => e.Address, address);
            var result = await _context.Collection<Workshop>().UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> ChangeDescription(string id, string description)
        {
            var filter = Builders<Workshop>.Filter.Eq(e => e.Id, id);
            var update = Builders<Workshop>.Update.Set(e => e.Description, description);
            var result = await _context.Collection<Workshop>().UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> RemoveWorker(string id, string workerId)
        {
            var filter = Builders<Workshop>.Filter.Eq(e => e.Id, id);
            var update = Builders<Workshop>.Update.Pull(e => e.RegisteredUsers, workerId);
            try
            {
                var result = await _context.Collection<Workshop>().UpdateOneAsync(filter, update);
                return result.ModifiedCount > 0;
            }
            catch (MongoWriteException ex)
            {
                throw new Exception("Worker not found", ex);
            }
        }

        public async Task<bool> CheckIfWorkerExists(string id, string workerId)
        {
            var filter = Builders<Workshop>.Filter.Where(e => e.Id == id && e.RegisteredUsers.Contains(workerId));
            var result = await _context.Collection<Workshop>().Find(filter).FirstOrDefaultAsync();
            return result != null;
        }
    }
}
