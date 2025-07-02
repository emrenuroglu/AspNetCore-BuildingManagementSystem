namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllBuildingQueryHandler : IRequestHandler<GetAllBuildingQueryRequest, GetAllBuildingQueryResponse>
    {
        private readonly IReadBuildingRepository _readApartmentRepository;

        public GetAllBuildingQueryHandler(IReadBuildingRepository readApartmentRepository)
        {
            _readApartmentRepository = readApartmentRepository;
        }
        public Task<GetAllBuildingQueryResponse> Handle(GetAllBuildingQueryRequest request, CancellationToken cancellationToken)
        {
            var totalApartmentCount = _readApartmentRepository.FindAll(false).Count();

            var apartments = _readApartmentRepository.FindAll(false)
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .Select(a => new Building
                {
                    Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    BuildingNo = a.BuildingNo,
                    TotalFloors = a.TotalFloors,
                    TotalApartments = a.TotalApartments,
                    TotalCarSpaces = a.TotalCarSpaces,
                })
                .ToList();

            return Task.FromResult(new GetAllBuildingQueryResponse
            {
                TotalApartmentCount = totalApartmentCount,
                Buildings = apartments
            });
        }
    }
}
