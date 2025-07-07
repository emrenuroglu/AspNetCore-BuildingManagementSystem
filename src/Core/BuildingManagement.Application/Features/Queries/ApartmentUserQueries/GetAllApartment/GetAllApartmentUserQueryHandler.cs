using BuildingManagement.Application.Contracts;

namespace BuildingManagement.Application.Features.Queries.ApartmentUserQueries.GetAllApartment
{
    public class GetAllApartmentUserQueryHandler : IRequestHandler<GetAllApartmentUserQueryRequest, GetAllApartmentUserQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllApartmentUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllApartmentUserQueryResponse> Handle(GetAllApartmentUserQueryRequest request, CancellationToken cancellationToken)
        {
            var apartmentUsers = await _unitOfWork.Read<ApartmentUser>().SelectAsync(
                x => new ApartmentUserDto
                {
                    Id = x.Id,
                    UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                    KatDaire = $"{x.Apartment.Floor}. Kat {x.Apartment.Number ?? "Bilinmiyor"} numarada",
                    BinaAdi = x.Apartment.Building.Name ?? "Bilinmiyor",
                    KullaniciTipi = x.IsOwner && !x.IsTenant ? "Malik" :
                                   x.IsTenant && !x.IsOwner ? "Kiracı" : "Tanımsız",
                    StartDate = x.StartDate.ToShortDateString(),
                    EndDate = x.EndDate.HasValue ? x.EndDate.Value.ToString("yyyy-MM-dd") : "Oturuyor"
                },
                query => query
                    .Include(a => a.Apartment)
                        .ThenInclude(b => b.Building)
                    .Include(a => a.User)
            );

            return new GetAllApartmentUserQueryResponse
            {
                ApartmentUsers = apartmentUsers
            };
        }
    }
}