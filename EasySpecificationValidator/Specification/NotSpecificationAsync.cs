using System;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class NotSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        internal NotSpecificationAsync(ISpecificationAsync<TEntity> specification)
        {
            Specification = specification ?? throw new ArgumentNullException(nameof(specification));
        }

        private ISpecificationAsync<TEntity> Specification { get; }

        public Func<TEntity, Task<bool>> Rule => null;

        /// <inheritdoc />
        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return !(await Specification.IsSatisfiedByAsync(candidate));
        }
    }
}