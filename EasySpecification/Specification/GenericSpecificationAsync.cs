using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> Rule { get; }

        /// <inheritdoc />
        public virtual async Task<bool> IsSatisfiedByAsync(TEntity entity)
        {
            var compiled = Rule.Compile();
            return await Task.FromResult(compiled(entity));
        }
    }
}