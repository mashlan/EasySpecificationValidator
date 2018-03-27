using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public abstract class SpecificationBaseAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        protected ISpecificationAsync<TEntity> LeftSpecification { get; }
        protected ISpecificationAsync<TEntity> RightSpecification { get; }

        /// <inheritdoc />
        protected SpecificationBaseAsync(ISpecificationAsync<TEntity> left, ISpecificationAsync<TEntity> right)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = right ?? throw new ArgumentNullException(nameof(right));
        }

        public Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <inheritdoc />
        public Func<TEntity, Task<bool>> Rule => null;

        /// <inheritdoc />
        public abstract Task<bool> IsSatisfiedByAsync(TEntity entity);

    }
}