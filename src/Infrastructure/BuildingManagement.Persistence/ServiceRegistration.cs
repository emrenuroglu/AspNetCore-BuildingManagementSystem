using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Application.Repository.TenancyRepository;
using BuildingManagement.Persistence.Context;
using BuildingManagement.Persistence.Repositories.ApartmentRepository;
using BuildingManagement.Persistence.Repositories.ApartmentUserRepository;
using BuildingManagement.Persistence.Repositories.TenancyRepository;
using BuildingManagement.Persistence.Repositories.UserRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
            collection.AddScoped<IWriteBuildingRepository, BuildingWriteRepository>();
            collection.AddScoped<IReadBuildingRepository, BuildingReadRepository>();
            collection.AddScoped<IWriteApartmentRepository, ApartmentWriteRepository>();
            collection.AddScoped<IReadApartmentRepository, ApartmentReadRepository>();
            collection.AddScoped<IWriteApartmentUserRepository, ApartmentUserWriteRepository>();
            collection.AddScoped<IReadApartmentUserRepository, ApartmentUserReadRepository>();
            collection.AddScoped<IWriteUserRepository, UserWriteRepository>();
            collection.AddScoped<IReadUserRepository, UserReadRepository>();
            collection.AddScoped<IReadTenancyRepository, TenancyReadRepository>();
            collection.AddScoped<IWriteTenancyRepository, TenancyWriteRepository>();
        }

        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            AppDbContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
