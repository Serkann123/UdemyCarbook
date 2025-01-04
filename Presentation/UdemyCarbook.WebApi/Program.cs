using UdemyCarbook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarbook.Application.Features.RepositoryPattern;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;
using UdemyCarbook.Application.Interfaces.CarInterfaces;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;
using UdemyCarbook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarbook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;
using UdemyCarbook.Persistence.Repositories;
using UdemyCarbook.Persistence.Repositories.BlogRepositories;
using UdemyCarbook.Persistence.Repositories.CarPirincingRepositories;
using UdemyCarbook.Persistence.Repositories.CarRepositories;
using UdemyCarbook.Persistence.Repositories.CommentRepositories;
using UdemyCarbook.Persistence.Repositories.StatisticsRepositories;
using UdemyCarbook.Persistence.Repositories.TagCloudRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<CarbookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPirincingRepository), typeof(CarPirincingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));

#region
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
#endregion

#region
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQýueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
#endregion

#region
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
#endregion

#region
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsQueryHandler>();
#endregion

#region
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
#endregion

#region
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
#endregion

builder.Services.AddAplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
