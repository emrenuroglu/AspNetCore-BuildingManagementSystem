using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllApartmentQueryRequest : IRequest<GetAllApartmentQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
