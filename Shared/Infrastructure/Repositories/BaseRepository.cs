using FurniGo.DataMapper.Shared.Infrastructure.Configuration;
using FurniGo.DataMapper.Shared.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.Shared.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class,  IEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            var collection = _context.Collection<TEntity>() ?? throw new InvalidOperationException("No se encontró la colección correspondiente en AppDbContext");
        }

        public async Task Create(TEntity entity)
        {
            await _context.Collection<TEntity>().InsertOneAsync(entity);
        }

        public async Task<TEntity> Delete(string id)
        {
            return await _context.Collection<TEntity>()
                .FindOneAndDeleteAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Collection<TEntity>().AsQueryable().ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _context.Collection<TEntity>()
                .Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _context.Collection<TEntity>()
                .FindOneAndUpdateAsync(e => e.Id == entity.Id, new UpdateDefinitionBuilder<TEntity>().Set(e => e, entity));
        }
    }
}
