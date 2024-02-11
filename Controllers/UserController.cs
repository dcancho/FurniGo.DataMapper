using Microsoft.AspNetCore.Mvc;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.App.Domain.Repositories;
using FurniGo.DataMapper.Shared.Mapping;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.App.Domain.Models;
using MongoDB.Driver;
using FurniGo.DataMapper.App.Resources;

namespace FurniGo.DataMapper.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserRepository _userRepository;
    private readonly IMapper<User, AppUser, SocialNetworkMapperUser> _userMapper;
    private readonly ILogger<UserController> _logger;

	public UserController(IUserRepository userRepository, IMapper<User, AppUser, SocialNetworkMapperUser> userMapper, ILogger<UserController> logger)
	{
		_userRepository = userRepository;
        _userMapper = userMapper;
        _logger = logger;
	}

	[HttpGet("app/{id}")]
	public async Task<IActionResult> GetAppUser(string id)
	{
        var user = await _userRepository.GetById(id);
        if (user is null)
		{
			return NotFound();
		}
		else
		{
			return Ok(_userMapper.MapToType1(user));
		}
	}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SaveUserResource user)
    {
        try
        {
            var saveUser = new User
            {
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            await _userRepository.Create(saveUser);
            _logger.LogInformation($"User created with id {saveUser.Id}");
            return Ok();
        }
        catch (MongoWriteException e)
        {
            return BadRequest(e.InnerException);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}