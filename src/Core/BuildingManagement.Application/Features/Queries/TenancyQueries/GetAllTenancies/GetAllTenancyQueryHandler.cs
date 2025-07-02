

using BuildingManagement.Application.Features.Queries.TenancyQueries.GetAllTenancies;

namespace BuildingManagement.Application.Features.Queries.TenancyQueries.GetAllTenancy
{
    public class GetAllTenancyQueryHandler : IRequestHandler<GetAllTenancyQueryRequest, GetAllTenancyQueryResponse>
    {
        private readonly IReadTenancyRepository _readTenancyRepository;

        public GetAllTenancyQueryHandler(IReadTenancyRepository readTenancyRepository)
        {
            _readTenancyRepository = readTenancyRepository;
        }

        public async Task<GetAllTenancyQueryResponse> Handle(GetAllTenancyQueryRequest request, CancellationToken cancellationToken)
        {
            var tenancies = await _readTenancyRepository.FindAll(false)
                .Include(t => t.Apartment)
                    .ThenInclude(a => a.Building)
                .Include(t => t.Owner)
                .Include(t => t.Tenant)
                .ToListAsync();

            var dtoList = tenancies.Select(t => new TenancyDto
            {
                DaireSahibiAdi = $"{t.Owner.FirstName} {t.Owner.LastName}",
                DaireKiracisiAdi = $"{t.Tenant.FirstName} {t.Tenant.LastName}",
                BinaAdi = t.Apartment?.Building?.Name ?? "Bilinmiyor",
                KatDaire = $"{t.Apartment.Floor}. Kat {t.Apartment.Number ?? "Bilinmiyor"} numarada",
                StartDate = t.StartDate.ToString("yyyy-MM-dd")
            }).ToList();

            return new GetAllTenancyQueryResponse
            {
                Tenancies = dtoList
            };
        }
    }
}
