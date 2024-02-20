using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class AppMediaMapper : IMapper<Media, AppMedia>
	{
		public Media Map(AppMedia toMap)
		{
			return new Media
			{
				Id = toMap.Id,
				Title = toMap.Title,
				Description = toMap.Description,
				File = toMap.File,
				ContentId = toMap.ContentId,
				Filename = toMap.Filename
			};
		}

		public AppMedia Map(Media toMap)
		{
			return new AppMedia
			{
				Id = toMap.Id,
				Title = toMap.Title,
				Description = toMap.Description,
				File = toMap.File ?? [],
				ContentId = toMap.ContentId,
				Filename = toMap.Filename
			};
		}
	}
}