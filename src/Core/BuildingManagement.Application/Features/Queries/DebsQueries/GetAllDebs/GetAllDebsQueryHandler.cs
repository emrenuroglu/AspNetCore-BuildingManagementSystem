namespace BuildingManagement.Application.Features.Queries.DebsQueries.GetAllDebs
{
    public class GetAllDebsQueryHandler : IRequestHandler<GetAllDebsQueryRequest, GetAllDebsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDebsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAllDebsQueryResponse> Handle(GetAllDebsQueryRequest request, CancellationToken cancellationToken)
        {

            var debs = await _unitOfWork.Read<Debs>()
                .SelectAsync
                (x => new DebsDto
                {
                    Id = x.Id,
                    BinaAdi = x.Building.Name,
                    Aidat = x.Amount,
                    StartDate = x.StartDate.ToShortDateString(),
                    OlusturanKisi = x.CreatedBy.FirstName + " " + x.CreatedBy.LastName
                },
                query => query
                .Include(b => b.Building)
                .Include(u => u.CreatedBy)
                );

            return new GetAllDebsQueryResponse
            {
                Debs = debs
            };
        }
    }
}
