using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.ApartmentRepository
{
    public class BuildingReadRepository : ReadBaseRepository<Domain.Entities.Building>, IReadBuildingRepository
    {
        public BuildingReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
