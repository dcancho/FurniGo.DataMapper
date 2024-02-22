using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace FurniGo.DataMapper.Shared.Infrastructure.Configuration
{
	public class AppDbContext
	{
		private readonly IMongoClient _client;
		private readonly IMongoDatabase _database;
		private readonly GridFSBucket _gridFsBucket;

		public IMongoCollection<Chat> Chats => _database.GetCollection<Chat>("chats");
		public IMongoCollection<Media> Media => _database.GetCollection<Media>("media");
		public IMongoCollection<Message> Messages => _database.GetCollection<Message>("messages");
		public IMongoCollection<Order> Orders => _database.GetCollection<Order>("orders");
		public IMongoCollection<Post> Posts => _database.GetCollection<Post>("posts");
		public IMongoCollection<User> Users => _database.GetCollection<User>("users");
		public IMongoCollection<Workshop> Workshops => _database.GetCollection<Workshop>("workshops");
		public GridFSBucket gridFSBucket => _gridFsBucket;

		public AppDbContext(string connectionString = "mongodb://localhost:27017", string databaseName = "furnigo-dev")
		{
			_client = new MongoClient(connectionString);
			_database = _client.GetDatabase(databaseName);
			_gridFsBucket = new GridFSBucket(_database);
		}

		public IMongoCollection<TEntity>? Collection<TEntity>() where TEntity : class
		{
			var collectionProperty = GetType().GetProperties().FirstOrDefault(
					p => p.PropertyType == typeof(IMongoCollection<TEntity>));
			if (collectionProperty != null)
			{
				return collectionProperty.GetValue(this) as IMongoCollection<TEntity>;
			}
			else
			{
				throw new InvalidOperationException($"Collection for {typeof(TEntity).Name} not found");
			}
		}
	}
}
