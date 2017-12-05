using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        public AndSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            Spec1 = spec1 ?? throw new ArgumentNullException(nameof(spec1));
            Spec2 = spec2 ?? throw new ArgumentNullException(nameof(spec2));
        }

        private ISpecification<TEntity> Spec1 { get; }
        private ISpecification<TEntity> Spec2 { get; }

        public Func<bool> Rule => null;

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return Spec1.IsSatisfiedBy(candidate) && Spec2.IsSatisfiedBy(candidate);
        }

        public Expression<Func<TEntity, bool>> Predicate { get; set; }
    }
}