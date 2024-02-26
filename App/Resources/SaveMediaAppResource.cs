namespace FurniGo.DataMapper.App.Resources
{
	/// <summary>
	/// DTO for saving a media resource.
	/// </summary>
	public class SaveMediaAppResource
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public byte[] File { get; set; }
		public string Filename { get; set; }
	}
}