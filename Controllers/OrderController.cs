using Microsoft.AspNetCore.Mvc;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.Controllers;

/// <summary>
/// Controller for the Order entity. It provides basic CRUD operations for the Order entity.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
	public readonly IOrderRepository _orderRepository;
	public readonly IMapper<Order, AppOrder> _orderAppMapper;

	public readonly IMapper<AppOrder, SaveOrderAppResource> _appOrderResourceMapper;
	public readonly ILogger<OrderController> _logger;

	public OrderController(IOrderRepository orderRepository, IMapper<Order, AppOrder> orderAppMapper, IMapper<AppOrder, SaveOrderAppResource> appOrderResourceMapper, ILogger<OrderController> logger)
	{
		_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
		_orderAppMapper = orderAppMapper ?? throw new ArgumentNullException(nameof(orderAppMapper));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_appOrderResourceMapper = appOrderResourceMapper ?? throw new ArgumentNullException(nameof(appOrderResourceMapper));
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var orders = await _orderRepository.GetAll();
		var appOrders = orders.Select(_orderAppMapper.Map);
		return Ok(appOrders);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(string id)
	{
		var order = await _orderRepository.GetById(id);
		if (order == null)
		{
			return NotFound();
		}
		var appOrder = _orderAppMapper.Map(order);
		return Ok(appOrder);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] SaveOrderAppResource appOrder)
	{
		string appOrderJson = System.Text.Json.JsonSerializer.Serialize(appOrder);
		_logger.LogInformation(appOrderJson);
		var newOrder = _orderAppMapper.Map(_appOrderResourceMapper.Map(appOrder));
		await _orderRepository.Create(newOrder);
		return Ok(newOrder.Id);
	}

	[HttpPut("{id}/{field}")]
	public async Task<IActionResult> Update(string id, string field, [FromBody] string value)
	{
		switch (field)
		{
			case "status":
				await _orderRepository.UpdateStatusOrder(id, value);
				break;

			case "shippingAddress":
				await _orderRepository.UpdateShippingAddress(id, value);
				break;

			case "dueDate":
				DateOnly newDueDate;
				if (DateOnly.TryParse(value, out newDueDate))
				{
					await _orderRepository.UpdateDueDate(id, newDueDate);
					break;
				}
				else
				{
					return BadRequest();
				}

			case "budget":
				float newBudget;
				if (float.TryParse(value, out newBudget))
				{
					await _orderRepository.UpdateBudget(id, newBudget);
					break;
				}
				else
				{
					return BadRequest();
				}

			case "description":
				await _orderRepository.UpdateDescription(id, value);
				break;

			default:
				return BadRequest();
		}
		return Ok($"Updated {field} in object with id: {id} successfully.");
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(string id)
	{
		await _orderRepository.Delete(id);
		return Ok($"Deleted object with id: {id} successfully.");
	}

}