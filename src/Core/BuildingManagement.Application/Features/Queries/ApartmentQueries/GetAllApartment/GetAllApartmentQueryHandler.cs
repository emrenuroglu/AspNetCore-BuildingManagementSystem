using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Domain.Dtos;
using BuildingManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllApartmentQueryHandler : IRequestHandler<GetAllApartmentQueryRequest, GetAllApartmentQueryResponse>
    {
        private readonly IReadApartmentRepository _apartmentRepository;

        public GetAllApartmentQueryHandler(IReadApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public async Task<GetAllApartmentQueryResponse> Handle(GetAllApartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var apartments = _apartmentRepository
                .FindAll(false) // false => tracking kapalı
                .Include(a => a.Building) // Building verisi lazım çünkü bina adını çekeceğiz
                .Select(a => new ApartmentDto
                {
                    Id = a.Id,
                    Number = a.Number,
                    Floor = a.Floor,
                    BuildingName = a.Building.Name,
                    StartDate = a.StartDate,
                })
                .ToList();

            return new GetAllApartmentQueryResponse
            {
                Apartments = apartments
            };

        }
    }
}
