using FurniGo.DataMapper.Shared.Domain.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace FurniGo.DataMapper.Shared.Infrastructure.Configuration
{

	public class AppDbContext
	{
		/// <summary> 
		/// MongoDB client to interact with the MongoDB server.
		/// </summary>
		private readonly IMongoClient _client;

		/// <summary>
		/// MongoDB database to perform operations on.
		/// </summary>
		private readonly IMongoDatabase _database;

		/// <summary> 
		/// GridFS bucket to store and retrieve files.
		/// </summary>
		private readonly GridFSBucket _gridFsBucket;

		/// <summary> 
		/// MongoDB collection for Chat documents.
		/// </summary>
		public IMongoCollection<Chat> Chats => _database.GetCollection<Chat>("chats");

		/// <summary> 
		/// MongoDB collection for Media documents.
		/// </summary>
		public IMongoCollection<Media> Media => _database.GetCollection<Media>("media");

		/// <summary> 
		/// MongoDB collection for Message documents
		/// </summary>
		public IMongoCollection<Message> Messages => _database.GetCollection<Message>("messages");

		/// <summary>
		/// MongoDB collection for Order documents.
		/// </summary>
		public IMongoCollection<Order> Orders => _database.GetCollection<Order>("orders");

		/// <summary>
		/// MongoDB collection for Post documents.
		/// </summary>
		public IMongoCollection<Post> Posts => _database.GetCollection<Post>("posts");

		/// <summary>
		/// MongoDB collection for User documents.
		/// </summary>
		public IMongoCollection<User> Users => _database.GetCollection<User>("users");

		/// <summary>
		/// MongoDB collection for Workshop documents.
		/// </summary>
		public IMongoCollection<Workshop> Workshops => _database.GetCollection<Workshop>("workshops");

		/// <summary>
		/// GridFS bucket to store and retrieve files.
		/// </summary>
		public GridFSBucket gridFSBucket => _gridFsBucket;

		public AppDbContext(string connectionString, string databaseName)
		{
			_client = new MongoClient(connectionString);
			_database = _client.GetDatabase(databaseName);
			_gridFsBucket = new GridFSBucket(_database);
		}

		/// <summary>
		/// Gets a collection from the database based on a provided type. If not found, returns an InvalidOperationException.
		/// </summary>
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
