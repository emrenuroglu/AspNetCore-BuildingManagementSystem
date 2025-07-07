namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.CreateApartment
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommandRequest, CreateApartmentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateApartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateApartmentCommandResponse> Handle(CreateApartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var apartment = new Apartment
            {
                BuildingId = request.BuildingId,
                Floor = request.Floor,
                Number = request.Number
            };
            await _unitOfWork.Write<Apartment>().CreateAsync(apartment);
            await _unitOfWork.SaveChangesAsync();

            return new CreateApartmentCommandResponse().ToCreateMessage(apartment.Id);
        }
    }
}
