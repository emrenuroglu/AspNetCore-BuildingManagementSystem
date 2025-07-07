namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllApartmentQueryHandler : IRequestHandler<GetAllApartmentQueryRequest, GetAllApartmentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllApartmentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAllApartmentQueryResponse> Handle(GetAllApartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var apartments = await _unitOfWork.Read<Apartment>().SelectAsync(
                a => new ApartmentDto
                {
                    Id = a.Id,
                    Number = a.Number,
                    Floor = a.Floor,
                    BuildingName = a.Building.Name,
                    StartDate = a.StartDate,
                },
                query => query.Include(a => a.Building)
            );

            return new GetAllApartmentQueryResponse
            {
                Apartments = apartments
            };

        }
    }
}
