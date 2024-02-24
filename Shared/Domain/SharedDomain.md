# Shared context Domain

## Models

### Mapping

#### [IMapper<T1, T2>](./Mapping/IMapper.cs)

> Implements: None
> Inherits: None

Interface for mapping objects from one type to another.

- Fields:
  - None
- Methods:
  - `T2 Map<T1, T2>(T1 source)`
  - `T1 Map<T1, T2>(T2 source)`

### Models

#### [IEntity](./Models/IEntity.cs)

> Implements: None
> Inherits: None       

Interface for entities related to the database.

- Fields:
  - `string Id { get; set; }`  
    Identifier of the entity.
- Methods:
  - None

#### [Chat](./Models/Chat.cs)

> Implements: [IEntity](./Models/IEntity.cs)  
> Inherits: None

Chat entity for grouping [Message](./Models/Message.cs) entities to represent a conversation between two or more users.

- Fields:
  - `string Id { get; set; }`
- Methods:
  - None

#### [Media](./Models/Media.cs)

> Implements: [IEntity](./Models/IEntity.cs)  
> Inherits: None

Media entity representing a media file in the system.

- Fields:
  - `string Id { get; set; }`  
    Identifier of the media.
  - `string Title { get; set; }`  
    Title of the media element. User defined.
  - `string Filename { get; set; }`  
    Filename of the media.
  - `string Description { get; set; }`
    Description of the media element. User defined.
  - `string PosterId { get; set; }`
    Identifier of the user who uploaded the media.
  - `string ContentId { get; set; }`
    Identifier of the content in the instance the byte array is stored.
  - `long FileSize { get; set; }`
    Size of the media file in bytes.
  - `byte[]? File { get; set; }`
    Byte array of the media file. Might be null if the media was requested as a reference to the API endpoint.
- Methods:
  - None

#### [Order](./Models/Order.cs)

> Implements: [IEntity](./Models/IEntity.cs)  
> Inherits: None

Order entity representing an order in the system.

- Fields:
  - `string Id { get; set; }`  
    Identifier of the order.
  - `string CustomerId { get; set; }`  
    Identifier of the user who placed the order.
  - `string? WorkshopId { get; set; }`  
    Identifier of the workshop where the order was placed. Might be null if the order hasn't been assigned to a workshop yet.
  - `string ShippingAddress { get; set; }`  
    Address where the order will be shipped.
  - `string Status { get; set; }`  
    Status of the order. Can be `Pending`, `Accepted`, `Rejected`, `InProcess`, `Ready`, `Delivered` or `Cancelled`.
  - `DateOnly DueDate { get; set; }`  
    Due date of the order.
  - `float Budget { get; set; }`  
    Budget of the order. Starts as a client defined value and then is adjusted to the real cost of the order.
  - `string Description { get; set; }`  
    Description of the order.
- Methods:
  - None

#### [Post](./Models/Post.cs)

> Implements: [IEntity](./Models/IEntity.cs)  
> Inherits: None

Post entity representing a post in the system.

- Fields:
  - `string Id { get; set; }`  
    Identifier of the post.
- Methods:
  - None

#### [User](./Models/User.cs)

> Implements: [IEntity](./Models/IEntity.cs)  
> Inherits: None

User entity representing a user in the system.

- Fields:
  - `string Id { get; set; }`  
    Identifier of the user.
  - `string Username { get; set; }`  
    Username of the user.
  - `string Password { get; set; }`  
    Password of the user.
  - `string FirstName { get; set; }`  
    First name of the user.
  - `string LastName { get; set; }`  
    Last name of the user.
  - `string PhoneNumber { get; set; }`  
    Phone number of the user.
  - `string Email { get; set; }`  
    Email of the user.
  - `string UserRole { get; set; }`  
    Role of the user. Can be `Admin`, `Customer` or `Worker`.
  - `string Address { get; set; }`  
    Address of the user.
- Methods:
  - None

#### [Message](./Models/Message.cs)

> Implements: [IEntity](./Models/IEntity.cs)
> Inherits: None

Message entity representing a message in the system.

- Fields:
  - `string Id { get; set; }`
    Identifier of the message.
- Methods:
  - None

#### [Workshop](./Models/Workshop.cs)

> Implements: [IEntity](./Models/IEntity.cs)
> Inherits: None

Workshop entity representing a workshop in the system.

- Fields:
  - `string Id { get; set; }`
    Identifier of the workshop.
  - `string Name { get; set; }`
    Name of the workshop.
  - `string Description { get; set; }`
    Description of the workshop.
  - `string Address { get; set; }`
    Address of the workshop.
  - `List<string> RegisteredUsers { get; set; }`
    List of users registered as workers in the workshop.
- Methods:
  - None

### Repositories

#### [IBaseRepository<T>](./Repositories/IBaseRepository.cs)

> Implements: None
> Inherits: None

Interface for a generic repository. It provides basic CRUD operations for the entities.

- Fields:
	- None
- Methods:
	- `Task<T> Create(T entity)`
	- `Task<T> GetById(string id)`
	- `Task<IEnumerable<T>> GetAll()`
	- `Task<T> Update(T entity)`
	- `Task<T> Delete(string id)`

#### [IUserRepository](./Repositories/IUserRepository.cs)

> Implements: [IBaseRepository](./Repositories/IBaseRepository.cs)<[User](./Models/User.cs)>
> Inherits: None

Interface for the user repository. Specifies additional methods for the user entity repository other than CRUD operations.

- Fields:
	- None
- Methods:
	- None
