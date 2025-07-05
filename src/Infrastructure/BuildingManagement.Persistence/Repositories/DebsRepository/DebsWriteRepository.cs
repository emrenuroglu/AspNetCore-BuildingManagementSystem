using BuildingManagement.Application.Repository.DebsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.DebsRepository
{
    public class DebsWriteRepository : WriteBaseRepository<Debs>, IWriteDebsRepository
    {
        public DebsWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
