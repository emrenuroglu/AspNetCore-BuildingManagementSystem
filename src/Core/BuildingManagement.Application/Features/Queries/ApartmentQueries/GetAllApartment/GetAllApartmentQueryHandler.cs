using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllApartmentQueryHandler : IRequestHandler<GetAllApartmentQueryRequest, GetAllApartmentQueryResponse>
    {
        private readonly IReadApartmentRepository _readApartmentRepository;

        public GetAllApartmentQueryHandler(IReadApartmentRepository readApartmentRepository)
        {
            _readApartmentRepository = readApartmentRepository;
        }
        public Task<GetAllApartmentQueryResponse> Handle(GetAllApartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var totalApartmentCount = _readApartmentRepository.FindAll(false).Count();

            var apartments = _readApartmentRepository.FindAll(false)
                .Skip((request.Page - 1) * request.Size) // ✅ düzeltildi
                .Take(request.Size)
                .Select(a => new Apartment
                {
                    Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    CreatedDate = a.CreatedDate,
                    TotalUnits = a.TotalUnits,   
                })
                .ToList();

            return Task.FromResult(new GetAllApartmentQueryResponse
            {
                TotalApartmentCount = totalApartmentCount,
                Apartments = apartments
            });
        }
    }
}
