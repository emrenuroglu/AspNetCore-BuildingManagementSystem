
namespace BuildingManagement.Application.Features.Commands.TenancyCommands.CreateTenancy
{
    public class CreateTenancyCommandRequest:IRequest<CreateTenancyCommandResponse>
    {
        public Guid ApartmentId { get; set; }

        public Guid TenantId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
