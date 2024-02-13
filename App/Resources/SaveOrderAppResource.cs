namespace FurniGo.DataMapper.App.Resources
{
    public class SaveOrderAppResource{
			public string CustomerId { get; set; }
			public string? WorkshopId { get; set; }
			public string ShippingAddress { get; set; }
			public string Status { get; set; }
			public DateOnly DueDate { get; set; }
			public float Budget { get; set; }
			public string Description { get; set; }
		}
}