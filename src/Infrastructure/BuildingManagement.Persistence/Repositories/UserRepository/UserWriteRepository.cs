using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.UserRepository
{
    public class UserWriteRepository : WriteBaseRepository<User>, IWriteUserRepository
    {
        public UserWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
