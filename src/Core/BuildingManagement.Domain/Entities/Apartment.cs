using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int TotalUnits { get; set; }
        public ICollection<ApartmentUnit> Units { get; set; } = new List<ApartmentUnit>();
        public ICollection<FeePlan> FeePlans { get; set; } = new List<FeePlan>();
    }
}
