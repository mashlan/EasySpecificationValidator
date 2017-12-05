using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public interface ISpecificationAsync<TEntity>
    {

        Func<Task<bool>> Rule { get; }

        Task<bool> IsSatisfiedByAsync(TEntity entity);
    }
}