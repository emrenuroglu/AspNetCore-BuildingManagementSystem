using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class ApartmentUser : BaseEntity
    {
        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsOwner { get; set; }
        public bool IsTenant { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
