using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Rule { get; }

        bool IsSatisfiedBy(TEntity entity);
    }
}