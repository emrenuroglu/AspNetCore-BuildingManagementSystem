using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.ApartmentUserRepository
{
    public class ApartmentUserReadRepository : ReadBaseRepository<ApartmentUser>, IReadApartmentUserRepository
    {
        public ApartmentUserReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
