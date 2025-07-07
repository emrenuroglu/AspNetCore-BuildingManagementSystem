namespace BuildingManagement.Application.Features.Queries.ApartmentQueries.GetAllApartment
{
    public class GetAllBuildingQueryResponse
    {
        public int TotalBinaCount { get; set; }
        public List<Building> Buildings { get; set; }
    }
}
