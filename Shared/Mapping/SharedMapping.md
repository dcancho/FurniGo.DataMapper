# Shared context Mapping

#### [UserResourceMapper](./Mapping/UserResourceMapper.cs)

> Implements: [IMapper](./Mapping/IMapper.cs)<[User](./../Domain/Models/User.cs), [SaveUserResource](./../../App/Resources/SaveUserResource.cs)>
> Inherits: None

Mapper from [User](./../Domain/Models/User.cs) to [SaveUserResource](./../../App/Resources/SaveUserResource.cs) and vice versa for saving new users.

- Fields:
	- None
- Methods:
	- `SaveUserResource Map(User source)`
	- `User Map(SaveUserResource source)`