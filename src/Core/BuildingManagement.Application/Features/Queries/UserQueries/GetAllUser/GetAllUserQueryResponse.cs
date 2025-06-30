using BuildingManagement.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryResponse
    {
        public List<UserDto> Users { get; set; }
    }
}
