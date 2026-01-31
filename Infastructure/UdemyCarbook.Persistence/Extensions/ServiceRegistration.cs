using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

namespace UdemyCarbook.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarbookContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICarPirincingRepository, CarPirincingRepository>();
            services.AddScoped<ITagCloudRepository, TagCloudRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<IRentACarRepository, RentACarRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<ICarDescriptionInterfaces, CarDescriptionRepositories>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepositories>();
        }
    }
}
