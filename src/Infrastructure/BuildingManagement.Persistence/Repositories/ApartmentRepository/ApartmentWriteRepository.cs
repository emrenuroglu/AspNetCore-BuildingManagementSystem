using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.ApartmentRepository
{
    public class ApartmentWriteRepository : WriteBaseRepository<Apartment>, IWriteApartmentRepository
    {
        public ApartmentWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
