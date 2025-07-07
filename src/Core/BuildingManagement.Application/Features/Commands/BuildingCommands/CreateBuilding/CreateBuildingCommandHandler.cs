namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommandRequest, CreateBuildingCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBuildingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBuildingCommandResponse> Handle(CreateBuildingCommandRequest request, CancellationToken cancellationToken)
        {

            var building = new Building
            {
                Name = request.Name,
                Address = request.Address,
                BuildingNo = request.BuildingNo,
                TotalFloors = request.TotalFloors,
                TotalApartments = request.TotalApartments,
                TotalCarSpaces = request.TotalCarSpaces
            };
            await _unitOfWork.Write<Building>().CreateAsync(building);
            await _unitOfWork.SaveChangesAsync();

            return new CreateBuildingCommandResponse().ToCreateMessage(building.Id);
        }
    }
}
