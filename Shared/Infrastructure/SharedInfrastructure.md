# Shared context Infrastructure

## Configuration

#### [AppDbContext](./Configuration/AppDbContext.cs)

> Implements: None
> Inherits: None

Database context for the application. Handles the connection to the database and the entities.
Current implementation, as of version 1.0, is fitted for MongoDB.

- Fields:
  - `IMongoClient _client`  
     MongoDB client for the connection to the database.
  - `IMongoDatabase _database`  
     MongoDB database for the connection to the database.
  - `GridFSBucket _gridFsBucket`  
     MongoDB GridFS bucket for the connection to the database.
  - `IMongoCollection<Chat> Chats`  
     MongoDB collection for the Chat entities.
  - `IMongoCollection<Message> Messages`
    MongoDB collection for the Message entities.
  - `IMongoCollection<Media> Media`
    MongoDB collection for the Media entities.
  - `IMongoCollection<Order> Orders`
    MongoDB collection for the Order entities.
  - `IMongoCollection<Post> Posts`
    MongoDB collection for the Post entities.
  - `IMongoCollection<User> Users`
    MongoDB collection for the User entities.
  - `IMongoCollection<Workshop> Workshops`
    MongoDB collection for the Workshop entities.
  - `GridFSBucket gridFSBucket`
    GridFSBucket instance for handling media files.
- Methods:
	- `IMongoCollection<T>? Collection<T>() where T : class`  
	  Get a collection from the database based on a provided type. If not found, returns an InvalidOperationException.

## Repositories

#### [BaseRepository<T>](./Repositories/BaseRepository.cs)
