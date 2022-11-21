using Cone.InventoryManagement.Application.Contracts.Persistence;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Persistence.Repositories;
using Cone.InventoryManagement.Persistence.Repositories.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cone.InventoryManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConeDatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConeInventoryManagement"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientSetupRepository, ClientSetupRepository>();
            services.AddScoped<IClientConnectionRepository, ClientConnectionRepository>();

            return services;
        }
    }
}
