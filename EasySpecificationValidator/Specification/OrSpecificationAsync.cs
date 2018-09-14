using System;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class OrSpecificationAsync<TEntity> : SpecificationBaseAsync<TEntity>
    {
        /// <inheritdoc />
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public OrSpecificationAsync(ISpecificationAsync<TEntity> left, ISpecificationAsync<TEntity> right)
            :base(left, right) { }

        /// <inheritdoc />
        public override async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await LeftSpecification.IsSatisfiedByAsync(candidate) || await RightSpecification.IsSatisfiedByAsync(candidate);
        }
    }
}