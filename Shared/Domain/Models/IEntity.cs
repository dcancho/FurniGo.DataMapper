namespace FurniGo.DataMapper.Shared.Domain.Models
{
	/// <summary>
	/// Interface for entities related to the database.
	/// </summary>
    public interface IEntity
    {
			/// <summary>
			/// The unique identifier for the entity.
			/// </summary>
        public string Id { get; set; }
    }
}
