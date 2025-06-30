using BuildingManagement.Application.Repository.ApartmentRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetByIdApartment
{
    public class GetByIdBuildingQueryHandler : IRequestHandler<GetByIdBuildingQueryRequest, GetByIdBuildingQueryResponse>
    {
        private readonly IReadBuildingRepository _readApartmentRepository;

        public GetByIdBuildingQueryHandler(IReadBuildingRepository readApartmentRepository)
        {
            _readApartmentRepository = readApartmentRepository;
        }
        public async Task<GetByIdBuildingQueryResponse> Handle(GetByIdBuildingQueryRequest request, CancellationToken cancellationToken)
        {
            var apartment = _readApartmentRepository.FindByCondition(a => a.Id == request.Id, false);

            if (apartment == null)
            {
                throw new KeyNotFoundException($"Apartment with ID {request.Id} not found.");
            }

            return new GetByIdBuildingQueryResponse
            {
                building = apartment
            };
        }
    }
}
