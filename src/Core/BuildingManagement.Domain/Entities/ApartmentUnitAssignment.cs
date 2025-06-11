using BuildingManagement.Domain.Common;
using BuildingManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class ApartmentUnitAssignment : BaseEntity
    {
        public Guid UnitId { get; set; }
        public ApartmentUnit? Unit { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public OccupancyType Type { get; set; } = OccupancyType.Owner;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
