using BuildingManagement.Application.Repository.ApartmentRepository;
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
        public Task<CreateApartmentCommandResponse> Handle(CreateApartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var apartment = new Domain.Entities.Apartment
            {
                BuildingId = request.BuildingId,
                Floor = request.Floor,
                Number = request.Number
            };
            _writeApartmentRepository.Create(apartment);
            _writeApartmentRepository.SaveChangesAsync();
            return Task.FromResult(new CreateApartmentCommandResponse
            {
                Message = "Daire başarıyla oluşturuldu.",
            });
        }
    }
}
