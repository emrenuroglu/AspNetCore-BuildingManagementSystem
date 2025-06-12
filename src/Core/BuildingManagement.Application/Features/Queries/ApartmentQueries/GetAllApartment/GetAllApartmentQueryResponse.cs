using BuildingManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllApartmentQueryResponse
    {
        public int TotalApartmentCount { get; set; }
        public List<Apartment> Apartments { get; set; }
    }
}
