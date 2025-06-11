using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class DebtType : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Aidat, Su, Elektrik, vb.
        public string? Description { get; set; }
    }
}
