using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public class AndSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        public AndSpecificationAsync(ISpecificationAsync<TEntity> left, ISpecificationAsync<TEntity> right)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = right ?? throw new ArgumentNullException(nameof(right));
        }

        private ISpecificationAsync<TEntity> LeftSpecification { get; }
        private ISpecificationAsync<TEntity> RightSpecification { get; }

        public Func<TEntity, Task<bool>> Rule => null;

        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await LeftSpecification.IsSatisfiedByAsync(candidate) && await RightSpecification.IsSatisfiedByAsync(candidate);
        }

        public Expression<Func<TEntity, bool>> Predicate { get; set; }
    }
}