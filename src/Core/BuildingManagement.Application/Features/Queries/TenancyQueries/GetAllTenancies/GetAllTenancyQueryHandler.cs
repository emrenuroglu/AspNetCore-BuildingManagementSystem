namespace BuildingManagement.Application.Features.Queries.TenancyQueries.GetAllTenancy
{
    public class GetAllTenancyQueryHandler : IRequestHandler<GetAllTenancyQueryRequest, GetAllTenancyQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTenancyQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAllTenancyQueryResponse> Handle(GetAllTenancyQueryRequest request, CancellationToken cancellationToken)
        {
            var tenancy = await _unitOfWork.Read<Tenancy>().SelectAsync
                (t=> new TenancyDto
                {
                    DaireSahibiAdi = $"{t.Owner.FirstName} {t.Owner.LastName}",
                    DaireKiracisiAdi = $"{t.Tenant.FirstName} {t.Tenant.LastName}",
                    BinaAdi = t.Apartment.Building.Name ?? "Bilinmiyor",
                    KatDaire = $"{t.Apartment.Floor}. Kat {t.Apartment.Number ?? "Bilinmiyor"} numarada",
                    StartDate = t.StartDate.ToString("yyyy-MM-dd")
                },
                query => query
                    .Include(t => t.Apartment)
                        .ThenInclude(a => a.Building)
                    .Include(t => t.Owner)
                    .Include(t => t.Tenant)
                );

            return new GetAllTenancyQueryResponse
            {
                Tenancies = tenancy
            };
        }
    }
}
