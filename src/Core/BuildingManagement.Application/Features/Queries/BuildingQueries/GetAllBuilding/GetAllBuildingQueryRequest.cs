using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllBuildingQueryRequest : IRequest<GetAllBuildingQueryResponse>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 5;
    }
}
