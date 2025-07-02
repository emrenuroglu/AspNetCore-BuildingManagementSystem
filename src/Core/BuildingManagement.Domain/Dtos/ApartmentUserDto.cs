using BuildingManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Dtos
{
    public class ApartmentUserDto
    {
        public Guid Id { get; set; }
        public string UserFullName { get; set; }
        public string KatDaire { get; set; }
        public string BinaAdi { get; set; }
        public string KullaniciTipi { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}

