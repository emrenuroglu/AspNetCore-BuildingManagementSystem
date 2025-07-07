using BuildingManagement.Application.Contracts;
using BuildingManagement.Persistence.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection collection)
        {
            collection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
