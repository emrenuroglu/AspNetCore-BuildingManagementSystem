using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class PaymentDebt : BaseEntity
    {
        public Guid UnitId { get; set; }
        public ApartmentUnit? Unit { get; set; }
        public Guid DebtTypeId { get; set; }
        public DebtType? DebtType { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? Description { get; set; }
    }
}
