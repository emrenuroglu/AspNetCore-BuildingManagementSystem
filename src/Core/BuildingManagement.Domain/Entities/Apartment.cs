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
        public string Number { get; set; } //17  daire no 
        public int Floor { get; set; } // 2. kat
        public Guid BuildingId { get; set; }
        public Building Building { get; set; }
        public ICollection<ApartmentUser> ApartmentUsers { get; set; }
        public ICollection<Tenancy> Tenancies { get; set; }
    }
}
