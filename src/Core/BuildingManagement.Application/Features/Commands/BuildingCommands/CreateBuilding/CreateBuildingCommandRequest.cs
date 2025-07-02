namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateBuildingCommandRequest : IRequest<CreateBuildingCommandResponse>
    {
        public string Name { get; set; }
        public string BuildingNo { get; set; }
        public string Address { get; set; }
        public int TotalFloors { get; set; } // Örn: 10 katlı bina
        public int TotalApartments { get; set; } // Örn: 50 daireli bina
        public int TotalCarSpaces { get; set; } // Toplam otopark alanı sayısı
    }
}
