using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        internal NotSpecification(ISpecification<TEntity> spec)
        {
            Wrapped = spec ?? throw new ArgumentNullException(nameof(spec));
        }

        private ISpecification<TEntity> Wrapped { get; }

        public Func<bool> Rule => null;

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !Wrapped.IsSatisfiedBy(candidate);
        }
    }
}