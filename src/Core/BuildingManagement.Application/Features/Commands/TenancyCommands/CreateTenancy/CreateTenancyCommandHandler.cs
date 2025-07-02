


namespace BuildingManagement.Application.Features.Commands.TenancyCommands.CreateTenancy
{
    public class CreateTenancyCommandHandler : IRequestHandler<CreateTenancyCommandRequest, CreateTenancyCommandResponse>
    {
        private readonly IWriteTenancyRepository _writeTenancyRepository;

        public CreateTenancyCommandHandler(IWriteTenancyRepository writeTenancyRepository)
        {
            _writeTenancyRepository = writeTenancyRepository;
        }

        public async Task<CreateTenancyCommandResponse> Handle(CreateTenancyCommandRequest request, CancellationToken cancellationToken)
        {
            var tenancy = new Tenancy
            {
                ApartmentId = request.ApartmentId,
                TenantId = request.TenantId,
                OwnerId = request.OwnerId,
                
            };

            _writeTenancyRepository.Create(tenancy);
            await _writeTenancyRepository.SaveChangesAsync();

            return new CreateTenancyCommandResponse().ToCreateMessage(tenancy.Id);
        }
    }
}
