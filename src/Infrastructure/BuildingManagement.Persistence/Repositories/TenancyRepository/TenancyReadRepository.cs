using BuildingManagement.Application.Repository.TenancyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.TenancyRepository
{
    public class TenancyReadRepository : ReadBaseRepository<Tenancy>, IReadTenancyRepository
    {
        public TenancyReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
    
       


