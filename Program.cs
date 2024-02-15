using FurniGo.DataMapper.App.Domain.Models;
using FurniGo.DataMapper.App.Domain.Repositories;
using FurniGo.DataMapper.App.Infrastructure.Repositories;
using FurniGo.DataMapper.App.Mapping;
using FurniGo.DataMapper.App.Resources;
using FurniGo.DataMapper.Shared.Domain.Mapping;
using FurniGo.DataMapper.Shared.Domain.Models;
using FurniGo.DataMapper.Shared.Infrastructure.Configuration;

namespace FurniGo.DataMapper;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var connectionString = builder.Configuration["DATABASE_CONNECTION"];
		var databaseName = builder.Configuration["DATABASE_NAME"];

		if (string.IsNullOrEmpty(connectionString))
		{
			throw new ArgumentNullException("DATABASE_CONNECTION");
		}
		if (string.IsNullOrEmpty(databaseName))
		{
			throw new ArgumentNullException("DATABASE_NAME");
		}

		builder.Services.AddSingleton<AppDbContext>(sp => new AppDbContext(connectionString, databaseName));

		// builder.Services.AddScoped<IUserRepository, UserRepository>();
		// builder.Services.AddScoped<IMapper<User, AppUser>, AppUserMapper>();
		builder.Services.AddScoped<IOrderRepository, OrderRepository>();
		builder.Services.AddScoped<IMapper<Order, AppOrder>, AppOrderMapper>();
		builder.Services.AddScoped<IMapper<AppOrder, SaveOrderAppResource>, OrderResourceMapper>();

		// Workshop services
		builder.Services.AddScoped<IWorkshopRepository, WorkshopRepository>();
		builder.Services.AddScoped<IMapper<Workshop, AppWorkshop>, AppWorkshopMapper>();
		builder.Services.AddScoped<IMapper<AppWorkshop, SaveWorkshopAppResource>, WorkshopResourceMapper>();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}
