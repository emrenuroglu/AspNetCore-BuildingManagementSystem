
using BuildingManagement.Application.Repository.DebsRepository;

namespace BuildingManagement.Application.Features.Commands.DebsCommands.CreateDebs
{
    public class CreateDebsCommandHandler : IRequestHandler<CreateDebsCommandRequest, CreateDebsCommandResponse>
    {

        private readonly IWriteDebsRepository _writeDebsRepository;

        public CreateDebsCommandHandler(IWriteDebsRepository writeDebsRepository)
        {
            _writeDebsRepository = writeDebsRepository;
        }
        public async Task<CreateDebsCommandResponse> Handle(CreateDebsCommandRequest request, CancellationToken cancellationToken)
        {
            var debs = new Debs
            {
                BuildingId = request.BuildingId,
                Amount = request.Amount,
                CreatedById = request.CreatedById,
            };
            _writeDebsRepository.Create(debs);
             await _writeDebsRepository.SaveChangesAsync();
            return new CreateDebsCommandResponse().ToCreateMessage(debs.Id);
        }
    }
}
