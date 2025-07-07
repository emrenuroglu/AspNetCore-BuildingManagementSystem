namespace BuildingManagement.Application.Features.Commands.ApartmentUserCommands.CreateApartmentUser
{
    public class CreateApartmentUserCommandHandler : IRequestHandler<CreateApartmentUserCommandRequest, CreateApartmentUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateApartmentUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateApartmentUserCommandResponse> Handle(CreateApartmentUserCommandRequest request, CancellationToken cancellationToken)
        {
            var apartmentUser = new ApartmentUser
            {
                ApartmentId = request.ApartmentId,
                UserId = request.UserId,
                IsOwner = request.IsOwner,
                IsTenant = request.IsTenant
            };
            await _unitOfWork.Write<ApartmentUser>().CreateAsync(apartmentUser);
            await _unitOfWork.SaveChangesAsync();

            return new CreateApartmentUserCommandResponse().ToCreateMessage(apartmentUser.Id);
        }
    }
}
