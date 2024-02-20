using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.App.Mapping
{
	public class MediaResourceMapper : IMapper<AppMedia, SaveMediaAppResource>
	{
		public AppMedia Map(SaveMediaAppResource toMap)
		{
			return new AppMedia
			{
				Title = toMap.Title,
				Description = toMap.Description,
				File = toMap.File,
				Filename = toMap.Filename
			};
		}

		public SaveMediaAppResource Map(AppMedia toMap)
		{
			return new SaveMediaAppResource
			{
				Title = toMap.Title,
				Description = toMap.Description,
				File = toMap.File,
				Filename = toMap.Filename
			};
		}

	}
}