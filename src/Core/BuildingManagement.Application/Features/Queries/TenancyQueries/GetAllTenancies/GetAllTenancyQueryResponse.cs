using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Features.Queries.TenancyQueries.GetAllTenancies
{
    public class GetAllTenancyQueryResponse
    {
        public List<TenancyDto> Tenancies { get; set; }

    }
}
