namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetByIdApartment
{
    public class GetByIdBuildingQueryRequest : IRequest<GetByIdBuildingQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
