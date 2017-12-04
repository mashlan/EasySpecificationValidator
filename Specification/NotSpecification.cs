using System;

namespace EasySpecification.Specification
{
    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        internal NotSpecification(ISpecification<TEntity> spec)
        {
            Wrapped = spec ?? throw new ArgumentNullException(nameof(spec));
        }

        private ISpecification<TEntity> Wrapped { get; }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !Wrapped.IsSatisfiedBy(candidate);
        }
    }
}