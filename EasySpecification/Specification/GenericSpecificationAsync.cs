using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        public Expression<Func<TEntity, bool>> Rule { get; }

        /// <inheritdoc />
        public async Task<bool> IsSatisfiedByAsync(TEntity entity)
        {
            var compiled = Rule.Compile();
            return compiled(entity);
        }
    }
}