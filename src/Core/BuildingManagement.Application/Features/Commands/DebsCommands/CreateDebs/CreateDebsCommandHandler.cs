namespace BuildingManagement.Application.Features.Commands.DebsCommands.CreateDebs
{
    public class CreateDebsCommandHandler : IRequestHandler<CreateDebsCommandRequest, CreateDebsCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDebsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateDebsCommandResponse> Handle(CreateDebsCommandRequest request, CancellationToken cancellationToken)
        {
            var debs = new Debs
            {
                BuildingId = request.BuildingId,
                Amount = request.Amount,
                CreatedById = request.CreatedById,
            };
            await _unitOfWork.Write<Debs>().CreateAsync(debs);
            await _unitOfWork.SaveChangesAsync();

            return new CreateDebsCommandResponse().ToCreateMessage(debs.Id);
        }
    }
}
