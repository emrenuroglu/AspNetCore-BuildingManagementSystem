using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Persistence.Repositories.ApartmentRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection collection)
        {
            collection.AddScoped<IWriteApartmentRepository, ApartmentWriteRepository>();
            collection.AddScoped<IReadApartmentRepository, ApartmentReadRepository>();
        }
    }
}
