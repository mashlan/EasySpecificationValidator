using System;

namespace EasySpecification.Specification
{
    public interface ISpecification<in TEntity>
    {
        Func<bool> Rule { get; }

        bool IsSatisfiedBy(TEntity entity);
    }
}