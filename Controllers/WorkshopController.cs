using Microsoft.AspNetCore.Mvc;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Controllers;

/// <summary>
/// Controller for the Workshop entity. It provides basic CRUD operations for the Workshop entity.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class WorkshopController : ControllerBase
{
	public readonly IWorkshopRepository _workshopRepository;
	public readonly IMapper<Workshop, AppWorkshop> _workshopAppMapper;

	public readonly IMapper<AppWorkshop, SaveWorkshopAppResource> _appWorkshopResourceMapper;
	public readonly ILogger<WorkshopController> _logger;

	public WorkshopController(IWorkshopRepository workshopRepository, IMapper<Workshop, AppWorkshop> workshopAppMapper, IMapper<AppWorkshop, SaveWorkshopAppResource> appWorkshopResourceMapper, ILogger<WorkshopController> logger)
	{
		_workshopRepository = workshopRepository ?? throw new ArgumentNullException(nameof(workshopRepository));
		_workshopAppMapper = workshopAppMapper ?? throw new ArgumentNullException(nameof(workshopAppMapper));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_appWorkshopResourceMapper = appWorkshopResourceMapper ?? throw new ArgumentNullException(nameof(appWorkshopResourceMapper));
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var workshops = await _workshopRepository.GetAll();
		var appWorkshops = workshops.Select(_workshopAppMapper.Map);
		return Ok(appWorkshops);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(string id)
	{
		var workshop = await _workshopRepository.GetById(id);
		if (workshop == null)
		{
			return NotFound();
		}
		var appWorkshop = _workshopAppMapper.Map(workshop);
		return Ok(appWorkshop);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] SaveWorkshopAppResource appWorkshop)
	{
		var newWorkshop = _workshopAppMapper.Map(_appWorkshopResourceMapper.Map(appWorkshop));
		await _workshopRepository.Create(newWorkshop);
		return Ok(newWorkshop.Id);
	}

	[HttpPut("{id}/{field}")]
	public async Task<IActionResult> Update(string id, string field, [FromBody] string value)
	{
		switch (field)
		{
			case "address":
				await _workshopRepository.ChangeAddress(id, value);
				break;
			case "description":
				await _workshopRepository.ChangeDescription(id, value);
				break;
			case "addWorker":
				await _workshopRepository.AddNewWorker(id, value);
				break;
			case "removeWorker":
				await _workshopRepository.RemoveWorker(id, value);
				break;

			default:
				return BadRequest();
		}
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(string id)
	{
		await _workshopRepository.Delete(id);
		return Ok($"Deleted workshop with id: {id} successfully.");
	}

}
