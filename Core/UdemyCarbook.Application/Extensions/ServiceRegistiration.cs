using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UdemyCarbook.Application.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddAplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));

            // CQRS Handler'ları otomatik DI
            services.Scan(scan => scan
                .FromAssemblies(typeof(ServiceRegistiration).Assembly)
                .AddClasses(c => c
                    .Where(t =>
                        t.Name.EndsWith("Handler") &&
                        t.Namespace != null &&
                        t.Namespace.Contains("CQRS.Handlers")))
                .AsSelf()
                .WithScopedLifetime());
        }
    }
}
