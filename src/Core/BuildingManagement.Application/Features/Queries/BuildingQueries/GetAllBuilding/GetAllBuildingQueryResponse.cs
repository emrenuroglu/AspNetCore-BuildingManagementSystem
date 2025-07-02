namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllBuildingQueryResponse
    {
        public int TotalApartmentCount { get; set; }
        public List<Building> Buildings { get; set; }
    }
}
