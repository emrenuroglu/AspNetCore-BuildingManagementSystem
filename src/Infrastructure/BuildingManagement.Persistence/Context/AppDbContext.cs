using BuildingManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Apartment> Apartments => Set<Apartment>();
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Tenancy> Tenancies => Set<Tenancy>();
        public DbSet<ApartmentUser> ApartmentUsers => Set<ApartmentUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenancy>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.TenanciesAsOwner)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tenancy>()
                .HasOne(t => t.Tenant)
                .WithMany(u => u.TenanciesAsTenant)
                .HasForeignKey(t => t.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
