using System;

namespace EasySpecification.Specification
{
    public abstract class GenericSpecification<TEntity> : ISpecification<TEntity>
    {
        protected TEntity Entity;

        public abstract Func<bool> Rule { get; }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual bool IsSatisfiedBy(TEntity entity)
        {
            Entity = entity;
            return Rule.Invoke();
        }
    }
}