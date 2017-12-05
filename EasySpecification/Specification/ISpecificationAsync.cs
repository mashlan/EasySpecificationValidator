using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public interface ISpecificationAsync<TEntity>
    {

        Expression<Func<TEntity, bool>> Rule { get; }

        Task<bool> IsSatisfiedByAsync(TEntity entity);
    }
}