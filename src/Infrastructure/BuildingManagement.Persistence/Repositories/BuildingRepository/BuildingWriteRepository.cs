using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.ApartmentRepository
{
    public class BuildingWriteRepository : WriteBaseRepository<Building>, IWriteBuildingRepository
    {
        public BuildingWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
