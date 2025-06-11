using BuildingManagement.Domain.Common;
using BuildingManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Resident;
        public ICollection<ApartmentUnitAssignment> ApartmentAssignments { get; set; } = new List<ApartmentUnitAssignment>();
    }
}
