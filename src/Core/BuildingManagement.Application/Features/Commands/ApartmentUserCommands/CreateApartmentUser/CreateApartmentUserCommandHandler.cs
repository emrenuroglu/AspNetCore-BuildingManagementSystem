using BuildingManagement.Domain.Entities;

namespace BuildingManagement.Application.Features.Commands.ApartmentUserCommands.CreateApartmentUser
{
    public class CreateApartmentUserCommandHandler : IRequestHandler<CreateApartmentUserCommandRequest, CreateApartmentUserCommandResponse>
    {
        private readonly IWriteApartmentUserRepository _writeApartmentUserRepository;
        public CreateApartmentUserCommandHandler(IWriteApartmentUserRepository writeApartmentUserRepository)
        {
            _writeApartmentUserRepository = writeApartmentUserRepository;
        }
        public async Task<CreateApartmentUserCommandResponse> Handle(CreateApartmentUserCommandRequest request, CancellationToken cancellationToken)
        {
            var apartmentUser = new ApartmentUser
            {
                ApartmentId = request.ApartmentId,
                UserId = request.UserId,
                IsOwner = request.IsOwner,
                IsTenant = request.IsTenant
            };
             _writeApartmentUserRepository.Create(apartmentUser);
            await _writeApartmentUserRepository.SaveChangesAsync();

            return new CreateApartmentUserCommandResponse().ToCreateMessage(apartmentUser.Id);
        }
    }
}
