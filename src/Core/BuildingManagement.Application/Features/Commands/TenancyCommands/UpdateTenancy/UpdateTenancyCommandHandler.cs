namespace BuildingManagement.Application.Features.Commands.TenancyCommands.UpdateTenancy
{
    public class UpdateTenancyCommandHandler : IRequestHandler<UpdateTenancyCommandRequest, UpdateTenancyCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateTenancyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateTenancyCommandResponse> Handle(UpdateTenancyCommandRequest request, CancellationToken cancellationToken)
        {
            var tenancy = await _unitOfWork.Read<Tenancy>().FindSingleAsync(x => x.Id == request.Id);
            if (tenancy == null)
            {
                return new UpdateTenancyCommandResponse
                {
                    Message = "Kiralama bilgisi bulunamadı."
                };
            }

            var tenant = await _unitOfWork.Read<User>().FindSingleAsync(x => x.Id == request.TenantId);
            var owner = await _unitOfWork.Read<User>().FindSingleAsync(x => x.Id == request.OwnerId);
            var apartment = await _unitOfWork.Read<Apartment>().FindSingleAsync(x => x.Id == request.ApartmentId);

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

            _unitOfWork.Write<Tenancy>().Update(tenancy);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateTenancyCommandResponse().ToUpdateMessage(tenancy.Id);
        }
    }
}
