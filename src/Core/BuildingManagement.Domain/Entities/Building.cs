using BuildingManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }
        public string BuildingNo { get; set; } // string düşürme?
        public string Address { get; set; }
        public int TotalFloors { get; set; } // Örn: 10 katlı bina
        public int TotalApartments { get; set; } // Örn: 50 daireli bina
        public int TotalCarSpaces { get; set; } // Toplam otopark alanı sayısı

        public ICollection<Apartment> Apartments { get; set; }
    }
}
