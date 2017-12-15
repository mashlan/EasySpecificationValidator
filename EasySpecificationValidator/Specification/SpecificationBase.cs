using System;
using System.Linq.Expressions;

namespace EasySpecificationValidator.Specification
{
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
    {
        protected ISpecification<TEntity> LeftSpecification { get; }
        protected ISpecification<TEntity> RightSpecification { get; }

        protected SpecificationBase(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = right ?? throw new ArgumentNullException(nameof(right));
        }

        /// <inheritdoc />
        public Func<TEntity, bool> Rule => null;
        public Expression<Func<TEntity, bool>> Predicate { get; set; }


        /// <inheritdoc />
        public abstract bool IsSatisfiedBy(TEntity entity);

    }
}