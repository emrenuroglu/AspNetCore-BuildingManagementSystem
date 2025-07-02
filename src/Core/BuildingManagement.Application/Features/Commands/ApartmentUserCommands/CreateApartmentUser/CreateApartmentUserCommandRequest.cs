namespace BuildingManagement.Application.Features.Commands.ApartmentUserCommands.CreateApartmentUser
{
    public class CreateApartmentUserCommandRequest : IRequest<CreateApartmentUserCommandResponse>
    {
        public Guid ApartmentId { get; set; }
        public Guid UserId { get; set; }
        public bool IsOwner { get; set; }
        public bool IsTenant { get; set; }
    }
}
