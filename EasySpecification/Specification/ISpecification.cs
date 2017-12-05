using System;

namespace EasySpecification.Specification
{
    public interface ISpecification<in TEntity>
    {
        Func<TEntity, bool> Rule { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}