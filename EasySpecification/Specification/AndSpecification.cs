using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        public AndSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            LeftSpecification = spec1 ?? throw new ArgumentNullException(nameof(spec1));
            RightSpecification = spec2 ?? throw new ArgumentNullException(nameof(spec2));
        }

        private ISpecification<TEntity> LeftSpecification { get; }
        private ISpecification<TEntity> RightSpecification { get; }

        public Func<TEntity, bool> Rule => null;

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) && RightSpecification.IsSatisfiedBy(candidate);
        }

        public Expression<Func<TEntity, bool>> Predicate { get; set; }
    }
}