using System;

namespace EasySpecificationValidator.Specification
{
    public abstract class GenericSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract Func<TEntity, bool> Rule { get; }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual bool IsSatisfiedBy(TEntity entity)
        {
            return Rule(entity);
        }
    }
}