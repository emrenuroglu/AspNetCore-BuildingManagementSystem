using BuildingManagement.Application.Repository.UserRepository;
using BuildingManagement.Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
