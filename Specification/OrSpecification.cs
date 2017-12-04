using System;

namespace EasySpecification.Specification
{
    public class OrSpecification<TEntity> : ISpecification<TEntity>
    {
        public OrSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            Spec1 = spec1 ?? throw new ArgumentNullException(nameof(spec1));
            Spec2 = spec2 ?? throw new ArgumentNullException(nameof(spec2));
        }

        private ISpecification<TEntity> Spec1 { get; }
        private ISpecification<TEntity> Spec2 { get; }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return Spec1.IsSatisfiedBy(candidate) || Spec2.IsSatisfiedBy(candidate);
        }
    }
}