using Microsoft.AspNetCore.Mvc;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Controllers;

/// <summary>
/// Controller for the Media entity. It provides basic CRUD operations for the Media entity.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class MediaController : ControllerBase
{
	private readonly IMediaRepository _mediaRepository;
	private readonly IMapper<Media, AppMedia> _mediaAppMapper;
	private readonly IMapper<AppMedia, SaveMediaAppResource> _appMediaResourceMapper;
	private readonly ILogger<MediaController> _logger;

	public MediaController(IMediaRepository mediaRepository, IMapper<Media, AppMedia> mediaAppMapper, IMapper<AppMedia, SaveMediaAppResource> appMediaResourceMapper, ILogger<MediaController> logger)
	{
		_mediaRepository = mediaRepository ?? throw new ArgumentNullException(nameof(mediaRepository));
		_mediaAppMapper = mediaAppMapper ?? throw new ArgumentNullException(nameof(mediaAppMapper));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_appMediaResourceMapper = appMediaResourceMapper ?? throw new ArgumentNullException(nameof(appMediaResourceMapper));
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var media = await _mediaRepository.GetAll();
		var appMedia = media.Select(_mediaAppMapper.Map);
		return Ok(appMedia);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(string id)
	{
		var media = await _mediaRepository.GetById(id);
		if (media == null)
		{
			return NotFound();
		}
		var appMedia = _mediaAppMapper.Map(media);
		return Ok(appMedia);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] SaveMediaAppResource appMedia)
	{
		string appMediaJson = System.Text.Json.JsonSerializer.Serialize(appMedia);
		_logger.LogInformation(appMediaJson);
		var newMedia = _mediaAppMapper.Map(_appMediaResourceMapper.Map(appMedia));
		await _mediaRepository.Create(newMedia);
		return Ok(newMedia.Id);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(string id)
	{
		var media = await _mediaRepository.Delete(id);
		if (media == null)
		{
			return NotFound();
		}
		return NoContent();
	}
}