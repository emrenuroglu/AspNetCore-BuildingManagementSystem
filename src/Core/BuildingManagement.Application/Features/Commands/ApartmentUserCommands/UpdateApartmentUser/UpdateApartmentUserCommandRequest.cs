namespace BuildingManagement.Application.Features.Commands.ApartmentUserCommands.UpdateApartmentUser
{
    public class UpdateApartmentUserCommandRequest : IRequest<UpdateApartmentUserCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ApartmentId { get; set; }
        public bool IsOwner { get; set; }
        public bool IsTenant { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
