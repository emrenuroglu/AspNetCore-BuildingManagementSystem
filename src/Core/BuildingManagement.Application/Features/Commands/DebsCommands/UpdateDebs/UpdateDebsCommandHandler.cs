namespace BuildingManagement.Application.Features.Commands.DebsCommands.UpdateDebs
{
    public class UpdateDebsCommandHandler : IRequestHandler<UpdateDebsCommandRequest, UpdateDebsCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDebsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateDebsCommandResponse> Handle(UpdateDebsCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Read<Debs>().FindSingleAsync(x => x.Id.Equals(request.Id));

            if (entity == null)
            {
                return new UpdateDebsCommandResponse
                {
                    Message = "Debs not found."
                };
            }

            entity.Amount = request.Amount;
            entity.CreatedById = request.CreatedById;

            _unitOfWork.Write<Debs>().Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateDebsCommandResponse().ToUpdateMessage(entity.Id);

        }
    }
}

