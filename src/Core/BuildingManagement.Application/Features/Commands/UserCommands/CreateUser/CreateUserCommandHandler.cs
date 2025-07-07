namespace BuildingManagement.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                TcKimlikNo = request.TcKimlikNo,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                Role = request.Role
            };
            await _unitOfWork.Write<User>().CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new CreateUserCommandResponse().ToCreateMessage(user.Id);
        }
    }
}
