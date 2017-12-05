using System;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public class OrSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        public OrSpecificationAsync(ISpecificationAsync<TEntity> left, ISpecificationAsync<TEntity> right)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = right ?? throw new ArgumentNullException(nameof(right));
        }

        private ISpecificationAsync<TEntity> LeftSpecification { get; }
        private ISpecificationAsync<TEntity> RightSpecification { get; }

        public Func<TEntity, Task<bool>> Rule => null;

        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await LeftSpecification.IsSatisfiedByAsync(candidate) || await RightSpecification.IsSatisfiedByAsync(candidate);
        }
    }
}