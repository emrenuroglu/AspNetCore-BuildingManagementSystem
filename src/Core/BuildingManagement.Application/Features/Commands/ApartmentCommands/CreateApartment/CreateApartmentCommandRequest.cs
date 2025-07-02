namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateApartmentCommandRequest : IRequest<CreateApartmentCommandResponse>
    {
        public string Number { get; set; }
        public int Floor { get; set; }
        public Guid BuildingId { get; set; }
    }
}
