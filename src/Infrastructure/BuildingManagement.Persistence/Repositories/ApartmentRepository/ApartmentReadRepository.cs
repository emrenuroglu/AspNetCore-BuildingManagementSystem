using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.ApartmentRepository
{
    public class ApartmentReadRepository : ReadBaseRepository<Apartment>, IReadApartmentRepository
    {
        public ApartmentReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
