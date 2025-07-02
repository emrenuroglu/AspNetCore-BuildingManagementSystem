namespace BuildingManagement.Application.Features.Commands.ApartmentCommands.RemoveApartment
{
    public class RemoveBuildingCommandHandler : IRequestHandler<RemoveBuildingCommandRequest, RemoveBuildingCommandResponse>
    {

        private readonly IWriteBuildingRepository _writeApartmentRepository;
        private readonly IReadBuildingRepository _readApartmentRepository;

        public RemoveBuildingCommandHandler(IWriteBuildingRepository writeApartmentRepository, IReadBuildingRepository readApartmentRepository)
        {
            _writeApartmentRepository = writeApartmentRepository;
            _readApartmentRepository = readApartmentRepository;
        }
        public async Task<RemoveBuildingCommandResponse> Handle(RemoveBuildingCommandRequest request, CancellationToken cancellationToken)
        {

            var apartment = await _readApartmentRepository
                .FindByConditionAsync(x => x.Id == request.Id, false);


            // 2. Bulunamazsa hata fırlat
            if (apartment == null)
            {
                throw new KeyNotFoundException($"Apartment with ID {request.Id} not found.");
            }

            // 3. Sil
            _writeApartmentRepository.Remove(apartment);
            await _writeApartmentRepository.SaveChangesAsync();

            // 4. Yanıt dön
            return new RemoveBuildingCommandResponse().ToDeleteMessage(apartment.Id);

        }
    }
}
