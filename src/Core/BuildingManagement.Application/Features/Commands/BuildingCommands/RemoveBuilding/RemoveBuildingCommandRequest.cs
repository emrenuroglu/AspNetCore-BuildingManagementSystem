namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.RemoveApartment
{
    public class RemoveBuildingCommandRequest : IRequest<RemoveBuildingCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
