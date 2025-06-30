using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Persistence.Repositories.UserRepository
{
    public class UserReadRepository : ReadBaseRepository<User>, IReadUserRepository
    {
        public UserReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
