namespace BuildingManagement.Application.Features.Queries.ApartmentUserQueries.GetAllApartment
{
    public class GetAllApartmentUserQueryHandler : IRequestHandler<GetAllApartmentUserQueryRequest, GetAllApartmentUserQueryResponse>
    {
        private readonly IReadApartmentUserRepository _readApartmentUserRepository;

        public GetAllApartmentUserQueryHandler(IReadApartmentUserRepository readApartmentUserRepository)
        {
            _readApartmentUserRepository = readApartmentUserRepository;
        }
        public async Task<GetAllApartmentUserQueryResponse> Handle(GetAllApartmentUserQueryRequest request, CancellationToken cancellationToken)
        {
            var apartmentUsers = await _readApartmentUserRepository.FindAll(false)
                           .Include(a => a.Apartment)
                           .ThenInclude(b => b.Building)
                           .Include(a => a.User)
                           .ToListAsync();

            var dtoList = apartmentUsers.Select(x => new ApartmentUserDto
            {
                Id = x.Id,
                UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                KatDaire = $"{x.Apartment.Floor}. Kat {x.Apartment.Number ?? "Bilinmiyor"} numarada",
                BinaAdi = x.Apartment?.Building?.Name ?? "Bilinmiyor",

                KullaniciTipi = x.IsOwner && !x.IsTenant ? "Malik" :
                               x.IsTenant && !x.IsOwner ? "Kiracı" : "Tanımsız",
                StartDate = x.StartDate.ToShortDateString(),
                EndDate = x.EndDate.HasValue ? x.EndDate.Value.ToString("yyyy-MM-dd") : "Oturuyor"
            }).ToList();

            return new GetAllApartmentUserQueryResponse
            {
                ApartmentUsers = dtoList
            };
        }
    }
}
