using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UdemyCarbook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarbook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Application.Interfaces.AppRolesInterfaces;
using UdemyCarbook.Application.Interfaces.AppUserInterfaces;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;
using UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarbook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarbook.Application.Interfaces.CarInterfaces;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;
using UdemyCarbook.Application.Interfaces.CommentInterfaces;
using UdemyCarbook.Application.Interfaces.RentACarInterfaces;
using UdemyCarbook.Application.Interfaces.ReviewInterfaces;
using UdemyCarbook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarbook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Application.Validators.Review;
using UdemyCarbook.Application.Validators.Service;
using UdemyCarbook.Persistence.Context;
using UdemyCarbook.Persistence.Repositories;
using UdemyCarbook.Persistence.Repositories.AppRoleRepositories;
using UdemyCarbook.Persistence.Repositories.AppUserRepositories;
using UdemyCarbook.Persistence.Repositories.BlogRepositories;
using UdemyCarbook.Persistence.Repositories.CarDescriptionRepositories;
using UdemyCarbook.Persistence.Repositories.CarFeatureRepositories;
using UdemyCarbook.Persistence.Repositories.CarPirincingRepositories;
using UdemyCarbook.Persistence.Repositories.CarRepositories;
using UdemyCarbook.Persistence.Repositories.CommentRepositories;
using UdemyCarbook.Persistence.Repositories.RentACarRepositories;
using UdemyCarbook.Persistence.Repositories.ReviewRepositories;
using UdemyCarbook.Persistence.Repositories.StatisticsRepositories;
using UdemyCarbook.Persistence.Repositories.TagCloudRepositories;
using UdemyCarbook.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
         builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

builder.Services.AddDbContext<CarbookContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPirincingRepository, CarPirincingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarDescriptionInterfaces, CarDescriptionRepositories>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IAppRoleRepository, AppRoleRepositories>();

#region About
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
#endregion

#region Banner
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQýueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
#endregion

#region Brand
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
#endregion

#region Car
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsQueryHandler>();
builder.Services.AddScoped<GetCarMainCarFeatureQueryHandler>();
#endregion

#region Category
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
#endregion

#region Contact
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
#endregion

builder.Services.AddAplicationService(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();
builder.Services.AddAuthentication();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew=TimeSpan.Zero,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });


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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");

app.Run();
