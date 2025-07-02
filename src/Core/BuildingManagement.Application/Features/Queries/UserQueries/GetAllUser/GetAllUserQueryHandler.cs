namespace BuildingManagement.Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly IReadUserRepository _readUserRepository;

        public GetAllUserQueryHandler(IReadUserRepository readUserRepository)
        {
            _readUserRepository = readUserRepository;
        }

        public Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _readUserRepository
                .FindAll(false)
                .ToList() // önce veriyi çek
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    TcKimlikNo = u.TcKimlikNo,
                    PhoneNumber = u.PhoneNumber,
                    PasswordHash = u.PasswordHash,
                    Email = u.Email,
                    RoleName = u.Role.ToString()
                })
                .ToList();

            return Task.FromResult(new GetAllUserQueryResponse
            {
                Users = users,
            });
        }
    }
}
