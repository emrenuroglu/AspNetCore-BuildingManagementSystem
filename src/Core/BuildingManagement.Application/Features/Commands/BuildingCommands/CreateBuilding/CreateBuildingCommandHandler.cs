namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommandRequest, CreateBuildingCommandResponse>
    {
        private readonly IWriteBuildingRepository _writeApartmentRepository;

        public CreateBuildingCommandHandler(IWriteBuildingRepository writeApartmentRepository)
        {
            _writeApartmentRepository = writeApartmentRepository;
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
            _writeApartmentRepository.Create(building);
            await _writeApartmentRepository.SaveChangesAsync();
            return building.ToCreateResponse();
        }
    }
}
