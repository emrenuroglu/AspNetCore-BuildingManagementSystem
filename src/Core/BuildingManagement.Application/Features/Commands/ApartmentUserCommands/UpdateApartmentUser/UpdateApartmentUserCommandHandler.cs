
using BuildingManagement.Application.Features.Commands.ApartmentUserCommands.CreateApartmentUser;
using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Application.Repository.ApartmentUserRepository;
using BuildingManagement.Application.Repository.UserRepository;

namespace BuildingManagement.Application.Features.Commands.ApartmentUserCommands.UpdateApartmentUser
{
    public class UpdateApartmentUserCommandHandler : IRequestHandler<UpdateApartmentUserCommandRequest, UpdateApartmentUserCommandResponse>
    {
        private readonly IReadApartmentUserRepository _readApartmentUserRepository;
        private readonly IWriteApartmentUserRepository _writeApartmentUserRepository;
        private readonly IReadUserRepository _readUserRepository;
        private readonly IReadApartmentRepository _readApartmentRepository;
        public UpdateApartmentUserCommandHandler(
        IReadApartmentUserRepository readApartmentUserRepository,
        IWriteApartmentUserRepository writeApartmentUserRepository,
        IReadUserRepository readUserRepository,
        IReadApartmentRepository readApartmentRepository)
        {
            _readApartmentUserRepository = readApartmentUserRepository;
            _writeApartmentUserRepository = writeApartmentUserRepository;
            _readUserRepository = readUserRepository;
            _readApartmentRepository = readApartmentRepository;
        }
        public async Task<UpdateApartmentUserCommandResponse> Handle(UpdateApartmentUserCommandRequest request, CancellationToken cancellationToken)
        {
            var apartmentUser = await _readApartmentUserRepository.FindByConditionAsync(x => x.Id == request.Id, false);

            if (apartmentUser == null)
            {
                return new UpdateApartmentUserCommandResponse
                {
                    Message = "Daire kullanıcısı bulunamadı."
                };
            }

            var user = await _readUserRepository.FindByConditionAsync(x => x.Id == request.UserId, false);
            var apartment = await _readApartmentRepository.FindByConditionAsync(x => x.Id == request.ApartmentId, false);

            if (user == null || apartment == null)
            {
                return new UpdateApartmentUserCommandResponse
                {
                    Message = "Kullanıcı veya daire bulunamadı."
                };
            }

            apartmentUser.UserId = request.UserId;
            apartmentUser.ApartmentId = request.ApartmentId;
            apartmentUser.IsOwner = request.IsOwner;
            apartmentUser.IsTenant = request.IsTenant;
            apartmentUser.EndDate = request.EndDate;

            _writeApartmentUserRepository.Update(apartmentUser);
            await _writeApartmentUserRepository.SaveChangesAsync();

            return new UpdateApartmentUserCommandResponse().ToUpdateMessage(apartmentUser.Id);
        }
    }
}
