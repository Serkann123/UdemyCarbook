using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Persistence.Context;
using UdemyCarbook.Persistence.Repositories;

namespace UdemyCarbook.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarbookContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Persistence katmanındaki Repository sınıflarını interface'leriyle otomatik olarak DI'a ekler
            services.Scan(scan => scan
              .FromAssemblyOf<CarbookContext>()
              .AddClasses(c => c.Where(t =>
                  t.Name.EndsWith("Repository") &&
                  t.Namespace != null &&
                  t.Namespace.Contains("UdemyCarbook.Persistence.Repositories")))
              .AsImplementedInterfaces()
              .WithScopedLifetime());
        }
    }
}
