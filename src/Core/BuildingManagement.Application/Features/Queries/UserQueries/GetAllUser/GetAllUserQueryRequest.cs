using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
    {
    }
}
