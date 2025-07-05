using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Domain.Dtos
{
    public class DebsDto
    {
        public string BinaAdi { get; set; }
        public int Aidat { get; set; }

        public string StartDate { get; set; }
        public string OlusturanKisi { get; set; }
    }
}
