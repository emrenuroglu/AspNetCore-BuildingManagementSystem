namespace BuildingManagement.Application.Features.Commands.DebsCommands.CreateDebs
{
    public class CreateDebsCommandRequest : IRequest<CreateDebsCommandResponse>
    {
        public Guid BuildingId { get; set; }
        public int Amount { get; set; }
        public Guid CreatedById { get; set; }
    }
}
