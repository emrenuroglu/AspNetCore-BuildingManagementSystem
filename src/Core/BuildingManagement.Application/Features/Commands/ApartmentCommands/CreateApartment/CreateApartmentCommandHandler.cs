using BuildingManagement.Application.Extension;
using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommandRequest, CreateApartmentCommandResponse>
    {
        private readonly IWriteApartmentRepository _writeApartmentRepository;

        public CreateApartmentCommandHandler(IWriteApartmentRepository writeApartmentRepository)
        {
            _writeApartmentRepository = writeApartmentRepository;
        }

        public async Task<CreateApartmentCommandResponse> Handle(CreateApartmentCommandRequest request, CancellationToken cancellationToken)
        {

            var apartment = new Apartment
            {
                Name = request.Name,
                Address = request.Address,
                TotalUnits = request.TotalUnits
            };
            _writeApartmentRepository.Create(apartment);
            _writeApartmentRepository.SaveChanges();
            return apartment.ToCreateResponse();
        }
    }
}
