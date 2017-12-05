using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public interface ISpecification<TEntity>
    {
        Func<bool> Rule { get; }

        bool IsSatisfiedBy(TEntity entity);
    }
}