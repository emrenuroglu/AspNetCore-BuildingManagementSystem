namespace BuildingManagement.Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Read<User>().SelectAsync(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                TcKimlikNo = u.TcKimlikNo,
                PhoneNumber = u.PhoneNumber,
                PasswordHash = u.PasswordHash,
                Email = u.Email,
                RoleName = u.Role.ToString()
            });

            return new GetAllUserQueryResponse
            {
                Users = users,
            };
        }
    }
}
