using System;

namespace EasySpecification.Specification
{
    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        internal NotSpecification(ISpecification<TEntity> spec)
        {
            Wrapped = spec ?? throw new ArgumentNullException(nameof(spec));
        }

        private ISpecification<TEntity> Wrapped { get; }

        public Func<TEntity, bool> Rule => null;

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !Wrapped.IsSatisfiedBy(candidate);
        }
    }
}