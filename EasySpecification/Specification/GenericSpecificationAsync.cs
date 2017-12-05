using System;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        protected TEntity Entity;

        public abstract Func<Task<bool>> Rule { get; }
        
        /// <inheritdoc />
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual async Task<bool> IsSatisfiedByAsync(TEntity entity)
        {
            Entity = entity;
            return await Rule.Invoke();
        }
    }
}