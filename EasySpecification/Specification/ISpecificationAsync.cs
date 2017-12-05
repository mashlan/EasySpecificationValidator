using System;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public interface ISpecificationAsync<in TEntity>
    {
        Func<Task<bool>> Rule { get; }

        Task<bool> IsSatisfiedByAsync(TEntity entity);
    }
}