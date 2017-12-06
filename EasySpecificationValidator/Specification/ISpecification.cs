using System;

namespace EasySpecificationValidator.Specification
{
    public interface ISpecification<in TEntity>
    {
        Func<TEntity, bool> Rule { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}