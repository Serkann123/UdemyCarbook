using UdemyCarbook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarbook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Persistence.Context;
using UdemyCarbook.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region
builder.Services.AddScoped<CarbookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
