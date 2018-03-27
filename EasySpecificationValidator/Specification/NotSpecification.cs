using System;

namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> Wrapped { get; }

        public Func<TEntity, bool> Rule => null;

        /// <exception cref="ArgumentNullException">Condition.</exception>
        internal NotSpecification(ISpecification<TEntity> self)
        {
            Wrapped = self ?? throw new ArgumentNullException(nameof(self));
        }

        /// <inheritdoc />
        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !Wrapped.IsSatisfiedBy(candidate);
        }
    }
}