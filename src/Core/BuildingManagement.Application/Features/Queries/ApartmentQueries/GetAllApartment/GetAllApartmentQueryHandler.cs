namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllApartmentQueryHandler : IRequestHandler<GetAllApartmentQueryRequest, GetAllApartmentQueryResponse>
    {
        private readonly IReadApartmentRepository _apartmentRepository;

        public GetAllApartmentQueryHandler(IReadApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public async Task<GetAllApartmentQueryResponse> Handle(GetAllApartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var apartments = await _apartmentRepository
                .FindAll(false)
                .Include(a => a.Building)
                .Select(a => new ApartmentDto
                {
                    Id = a.Id,
                    Number = a.Number,
                    Floor = a.Floor,
                    BuildingName = a.Building.Name,
                    StartDate = a.StartDate,
                })
                .ToListAsync();

            return new GetAllApartmentQueryResponse
            {
                Apartments = apartments
            };

        }
    }
}
