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
        public DbSet<ApartmentUnit> ApartmentUnits => Set<ApartmentUnit>();
        public DbSet<ApartmentUnitAssignment> ApartmentUnitAssignments => Set<ApartmentUnitAssignment>();
        public DbSet<FeePlan> FeePlans => Set<FeePlan>();
        public DbSet<DebtType> DebtTypes => Set<DebtType>();
        public DbSet<PaymentDebt> PaymentDebts => Set<PaymentDebt>();
        public DbSet<Announcement> Announcements => Set<Announcement>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();
            modelBuilder.Entity<ApartmentUnitAssignment>().Property(a => a.Type).HasConversion<string>();
        }
    }
}
