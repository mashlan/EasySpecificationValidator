using System;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Specification
{
    public interface ISpecificationAsync<in TEntity>
    {
        Func<TEntity, Task<bool>> Rule { get; }
        Task<bool> IsSatisfiedByAsync(TEntity entity);
    }
}