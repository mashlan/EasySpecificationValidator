using System;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        public abstract Func<Task<bool>> Rule { get; }
        protected TEntity entity { get; set; }

        /// <inheritdoc />
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual async Task<bool> IsSatisfiedByAsync(TEntity entity)
        {
            this.entity = entity;
            return await Rule.Invoke();
        }
    }
}