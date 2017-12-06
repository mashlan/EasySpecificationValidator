using System;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Specification
{
    public abstract class GenericSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        public abstract Func<TEntity, Task<bool>> Rule { get; }
        
        /// <inheritdoc />
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual async Task<bool> IsSatisfiedByAsync(TEntity entity)
        {
            return await Rule(entity);
        }
    }
}