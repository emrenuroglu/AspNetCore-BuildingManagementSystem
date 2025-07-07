namespace BuildingManagement.Application.Features.Commands.ApartmentUserCommands.UpdateApartmentUser
{
    public class UpdateApartmentUserCommandHandler : IRequestHandler<UpdateApartmentUserCommandRequest, UpdateApartmentUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateApartmentUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateApartmentUserCommandResponse> Handle(UpdateApartmentUserCommandRequest request, CancellationToken cancellationToken)
        {

            var apartmentUser = await _unitOfWork.Read<ApartmentUser>().FindSingleAsync(x => x.Id == request.Id);

            if (apartmentUser is null)
            {
                return new UpdateApartmentUserCommandResponse
                {
                    Message = "Daire kullanıcısı bulunamadı."
                };
            }

            var userExists = await _unitOfWork.Read<User>().ExistsAsync(x => x.Id == request.UserId);
            var apartmentExists = await _unitOfWork.Read<Apartment>().ExistsAsync(x => x.Id == request.ApartmentId);

            if (!userExists || !apartmentExists)
            {
                return new UpdateApartmentUserCommandResponse
                {
                    Message = "Kullanıcı veya daire bulunamadı."
                };
            }

            apartmentUser.UserId = request.UserId;
            apartmentUser.ApartmentId = request.ApartmentId;
            apartmentUser.IsOwner = request.IsOwner;
            apartmentUser.IsTenant = request.IsTenant;
            apartmentUser.EndDate = request.EndDate;

            _unitOfWork.Write<ApartmentUser>().Update(apartmentUser);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateApartmentUserCommandResponse().ToUpdateMessage(apartmentUser.Id);
        }
    }
}
