namespace BuildingManagement.Application.Features.Queries.DebsQueries.GetAllDebs
{
    public class GetAllDebsQueryHandler : IRequestHandler<GetAllDebsQueryRequest, GetAllDebsQueryResponse>
    {
        private readonly IReadDebsRepository _debsReadRepository;

        public GetAllDebsQueryHandler(IReadDebsRepository debsReadRepository)
        {
            _debsReadRepository = debsReadRepository;
        }
        public async Task<GetAllDebsQueryResponse> Handle(GetAllDebsQueryRequest request, CancellationToken cancellationToken)
        {
            var debs = await _debsReadRepository
                .FindAll(false)
                .Include(b => b.Building)
                .Include(u => u.CreatedBy)
                .Select(x => new DebsDto
                {
                    BinaAdi = x.Building.Name,
                    Aidat = x.Amount,
                    StartDate = x.StartDate.ToShortDateString(),
                    OlusturanKisi = x.CreatedBy.FirstName + " " + x.CreatedBy.LastName
                })
                .ToListAsync();

            return new GetAllDebsQueryResponse
            {
                Debs = debs
            };
        }
    }
}
