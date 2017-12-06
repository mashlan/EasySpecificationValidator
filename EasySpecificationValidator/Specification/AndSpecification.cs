using System;
using System.Linq.Expressions;

namespace EasySpecificationValidator.Specification
{
    public class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> LeftSpecification { get; }
        private ISpecification<TEntity> RightSpecification { get; }

        public Func<TEntity, bool> Rule => null;
        public Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = right ?? throw new ArgumentNullException(nameof(right));
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) && RightSpecification.IsSatisfiedBy(candidate);
        }
    }
}