using Microsoft.AspNetCore.Mvc;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.App.Domain.Models;
using MongoDB.Driver;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.IAM.Domain.Models;
using FurniGo.DataMapper.SocialNetwork.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper<User, AppUser> _userAppMapper;
	private readonly IMapper<User, IAMUser> _userIAMMapper;
	private readonly IMapper<User, SocialNetworkUser> _userSocialNetworkMapper;
	private readonly IMapper<User, SaveUserResource> _userResourceMapper;
	private readonly ILogger<UserController> _logger;

	public UserController(
		IUserRepository userRepository, 
		IMapper<User, AppUser> userAppMapper, 
		IMapper<User, IAMUser> userIAMMapper, 
		IMapper<User, SocialNetworkUser> userSocialNetworkMapper, 
		IMapper<User, SaveUserResource> userResourceMapper,
		ILogger<UserController> logger)
	{
		_userRepository = userRepository ?? 
			throw new ArgumentNullException(nameof(userRepository));
		_userAppMapper = userAppMapper ?? 
			throw new ArgumentNullException(nameof(userAppMapper));
		_userIAMMapper = userIAMMapper ?? 
			throw new ArgumentNullException(nameof(userIAMMapper));
		_userSocialNetworkMapper = userSocialNetworkMapper ?? 
			throw new ArgumentNullException(nameof(userSocialNetworkMapper));
		_userResourceMapper = userResourceMapper ?? 
			throw new ArgumentNullException(nameof(userResourceMapper));
		_logger = logger ?? 
			throw new ArgumentNullException(nameof(logger));
	}

    private async Task<IActionResult> GetUser<T>(string id, IMapper<User, T> mapper)
    {
        var user = await _userRepository.GetById(id);
        if (user is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(mapper.Map(user));
        }
    }

    [HttpGet("app/{id}")]
    public Task<IActionResult> GetAppUser(string id)
    {
        return GetUser(id, _userAppMapper);
    }

    [HttpGet("iam/{id}")]
    public Task<IActionResult> GetIAMUser(string id)
    {
        return GetUser(id, _userIAMMapper);
    }

    [HttpGet("social-network/{id}")]
    public Task<IActionResult> GetSocialNetworkUser(string id)
    {
        return GetUser(id, _userSocialNetworkMapper);
    }


    [HttpPost]
	public async Task<IActionResult> Post([FromBody] SaveUserResource user)
	{
		var userToCreate = _userResourceMapper.Map(user);
		await _userRepository.Create(userToCreate);
		return CreatedAtAction(nameof(GetAppUser), new { id = userToCreate.Id }, userToCreate);
	}

}