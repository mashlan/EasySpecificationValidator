using System;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract Func<bool> Rule { get; }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual bool IsSatisfiedBy(TEntity entity)
        {
            return Rule.Invoke();
        }
    }
}