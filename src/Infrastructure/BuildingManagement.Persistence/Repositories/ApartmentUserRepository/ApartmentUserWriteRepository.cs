using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.ApartmentUserRepository
{
    public class ApartmentUserWriteRepository : WriteBaseRepository<ApartmentUser>, IWriteApartmentUserRepository
    {
        public ApartmentUserWriteRepository(AppDbContext context) : base(context)
        {
        }

  
    }
}
