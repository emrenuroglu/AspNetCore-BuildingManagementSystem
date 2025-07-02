using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Dtos
{
    public class TenancyDto
    {
        public string DaireSahibiAdi { get; set; }
        public string DaireKiracisiAdi { get; set; }
        public string BinaAdi { get; set; }
        public string KatDaire { get; set; }
        public string StartDate { get; set; }
    }
}
