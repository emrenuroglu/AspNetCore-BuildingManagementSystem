namespace BuildingManagement.Application.Features.Commands.TenancyCommands.CreateTenancy
{
    public class CreateTenancyCommandHandler : IRequestHandler<CreateTenancyCommandRequest, CreateTenancyCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTenancyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTenancyCommandResponse> Handle(CreateTenancyCommandRequest request, CancellationToken cancellationToken)
        {
            var tenancy = new Tenancy
            {
                ApartmentId = request.ApartmentId,
                TenantId = request.TenantId,
                OwnerId = request.OwnerId,

            };

            await _unitOfWork.Write<Tenancy>().CreateAsync(tenancy);
            await _unitOfWork.SaveChangesAsync();


            return new CreateTenancyCommandResponse().ToCreateMessage(tenancy.Id);
        }
    }
}
