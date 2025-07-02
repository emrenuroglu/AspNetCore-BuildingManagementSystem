using BuildingManagement.Application.Repository.TenancyRepository;
using BuildingManagement.Application.Repository.ApartmentRepository;
using BuildingManagement.Application.Repository.UserRepository;
using MediatR;

namespace BuildingManagement.Application.Features.Commands.TenancyCommands.UpdateTenancy
{
    public class UpdateTenancyCommandHandler : IRequestHandler<UpdateTenancyCommandRequest, UpdateTenancyCommandResponse>
    {
        private readonly IReadTenancyRepository _readTenancyRepository;
        private readonly IWriteTenancyRepository _writeTenancyRepository;
        private readonly IReadUserRepository _readUserRepository;
        private readonly IReadApartmentRepository _readApartmentRepository;

        public UpdateTenancyCommandHandler(
            IReadTenancyRepository readTenancyRepository,
            IWriteTenancyRepository writeTenancyRepository,
            IReadUserRepository readUserRepository,
            IReadApartmentRepository readApartmentRepository)
        {
            _readTenancyRepository = readTenancyRepository;
            _writeTenancyRepository = writeTenancyRepository;
            _readUserRepository = readUserRepository;
            _readApartmentRepository = readApartmentRepository;
        }

        public async Task<UpdateTenancyCommandResponse> Handle(UpdateTenancyCommandRequest request, CancellationToken cancellationToken)
        {
            var tenancy = await _readTenancyRepository.FindByConditionAsync(x => x.Id == request.Id, false);
            if (tenancy == null)
            {
                return new UpdateTenancyCommandResponse
                {
                    Message = "Kiralama bilgisi bulunamadı."
                };
            }

            var tenant = await _readUserRepository.FindByConditionAsync(x => x.Id == request.TenantId, false);
            var owner = await _readUserRepository.FindByConditionAsync(x => x.Id == request.OwnerId, false);
            var apartment = await _readApartmentRepository.FindByConditionAsync(x => x.Id == request.ApartmentId, false);

            if (tenant == null || owner == null || apartment == null)
            {
                return new UpdateTenancyCommandResponse
                {
                    Message = "Kiracı, malik veya daire bulunamadı."
                };
            }

            tenancy.TenantId = request.TenantId;
            tenancy.OwnerId = request.OwnerId;
            tenancy.ApartmentId = request.ApartmentId;
            tenancy.EndDate = request.EndDate;

            _writeTenancyRepository.Update(tenancy);
            await _writeTenancyRepository.SaveChangesAsync();

            return new UpdateTenancyCommandResponse().ToUpdateMessage(tenancy.Id);
        }
    }
}
