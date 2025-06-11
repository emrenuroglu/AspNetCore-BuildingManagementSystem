using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class FeePlan : BaseEntity
    {
        public Guid ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public DateTime EffectiveFrom { get; set; } // Ne zaman yürürlüğe girecek
        public decimal Amount { get; set; }
        public Guid CreatedById { get; set; }
        public User? CreatedBy { get; set; }
    }
}
