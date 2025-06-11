using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class ApartmentUnit : BaseEntity
    {
        public string UnitNumber { get; set; } = string.Empty;
        public int? Floor { get; set; }
        public Guid ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public ICollection<ApartmentUnitAssignment> Assignments { get; set; } = new List<ApartmentUnitAssignment>();
    }
}
