namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetByIdApartment
{
    public class GetByIdBuildingQueryHandler : IRequestHandler<GetByIdBuildingQueryRequest, GetByIdBuildingQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdBuildingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetByIdBuildingQueryResponse> Handle(GetByIdBuildingQueryRequest request, CancellationToken cancellationToken)
        {
            var building = await _unitOfWork.Read<Building>().FindSingleAsync(b => b.Id == request.Id);

            if (building == null)
            {
                throw new KeyNotFoundException($"Apartment with ID {request.Id} not found.");
            }

            return new GetByIdBuildingQueryResponse
            {
                Building = building
            };
        }
    }
}
