using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class Tenancy : BaseEntity
    {
        public Guid ApartmentId { get; set; } 
        public Apartment Apartment { get; set; } // daire

        public Guid TenantId { get; set; }
        public User Tenant { get; set; } // kiracı

        public Guid OwnerId { get; set; }
        public User Owner { get; set; } //sahibi 
        public DateTime? EndDate { get; set; }
    }
}
