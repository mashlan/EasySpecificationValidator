using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> Rule { get; }

        public bool IsSatisfiedBy(TEntity entity)
        {
            var compiled = Rule.Compile();
            return compiled(entity);
        }

    }
}