using System;
using System.Linq.Expressions;

namespace EasySpecification.Specification
{
    public class OrSpecification<TEntity> : ISpecification<TEntity>
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> rigt)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = rigt ?? throw new ArgumentNullException(nameof(rigt));
        }

        private ISpecification<TEntity> LeftSpecification { get; }
        private ISpecification<TEntity> RightSpecification { get; }

        public Func<TEntity, bool> Rule => null;

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) || RightSpecification.IsSatisfiedBy(candidate);
        }
    }
}