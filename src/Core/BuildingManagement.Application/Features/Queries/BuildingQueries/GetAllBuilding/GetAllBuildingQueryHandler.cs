namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllBuildingQueryHandler : IRequestHandler<GetAllBuildingQueryRequest, GetAllBuildingQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBuildingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAllBuildingQueryResponse> Handle(GetAllBuildingQueryRequest request, CancellationToken cancellationToken)
        {
            var total = _unitOfWork.Read<Building>().CountAsync().Result;

            var buildings = await _unitOfWork.Read<Building>().SelectAsync(
                a => new Building
                {
                    Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    BuildingNo = a.BuildingNo,
                    TotalFloors = a.TotalFloors,
                    TotalApartments = a.TotalApartments,
                    TotalCarSpaces = a.TotalCarSpaces,
                }
            );

            return new GetAllBuildingQueryResponse
            {
                TotalBinaCount = total,
                Buildings = buildings,
            };
        }
    }
}
