using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Application.Repository
{
    public interface IReadBaseRepository<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
    }
}
