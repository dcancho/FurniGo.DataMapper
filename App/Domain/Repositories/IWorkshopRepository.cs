using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Repositories;

namespace FurniGo.DataMapper.App.Domain.Repositories
{
	public interface IWorkshopRepository : IBaseRepository<Workshop>
	{
		/// <summary>
		/// Add new worker to a workshop by it's id.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="workerId"></param>
		/// <returns></returns>
		Task<bool> AddNewWorker(string id, string workerId);
		/// <summary>
		/// Remove worker from a workshop by it's id.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="workerId"></param>
		/// <returns></returns>
		Task<bool> RemoveWorker(string id, string workerId);
		/// <summary>
		/// Change adress of the workshop.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="address"></param>
		/// <returns></returns>
		Task<bool> ChangeAddress(string id, string address);
		/// <summary>
		/// Change description of the workshop.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="description"></param>
		/// <returns></returns>
		Task<bool> ChangeDescription(string id, string description);
	}
}
