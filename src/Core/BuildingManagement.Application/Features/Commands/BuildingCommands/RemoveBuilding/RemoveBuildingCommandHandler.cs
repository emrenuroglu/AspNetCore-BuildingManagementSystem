namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.RemoveApartment
{
    public class RemoveBuildingCommandHandler : IRequestHandler<RemoveBuildingCommandRequest, RemoveBuildingCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveBuildingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RemoveBuildingCommandResponse> Handle(RemoveBuildingCommandRequest request, CancellationToken cancellationToken)
        {
            var apartment = await _unitOfWork.Read<Building>().FindSingleAsync(x => x.Id == request.Id);

            if (apartment == null)
            {
                throw new KeyNotFoundException($"Apartment with ID {request.Id} not found.");
            }

            _unitOfWork.Write<Building>().HardDelete(apartment);
            await _unitOfWork.SaveChangesAsync();

            return new RemoveBuildingCommandResponse().ToDeleteMessage(apartment.Id);

        }
    }
}
