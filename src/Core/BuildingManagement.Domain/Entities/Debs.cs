using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class Debs : BaseEntity
    {
        public Guid BuildingId { get; set; }
        public Building Building { get; set; }
        public int Amount { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}
