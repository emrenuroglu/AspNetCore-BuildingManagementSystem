using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Repository
{
    public interface IWriteBaseRepository<T>
    {
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task SaveChangesAsync();
    }
}
