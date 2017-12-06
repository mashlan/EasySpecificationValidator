using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public class AndSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        private ISpecificationAsync<TEntity> LeftSpecification { get; }
        private ISpecificationAsync<TEntity> RightSpecification { get; }

        public Func<TEntity, Task<bool>> Rule => null;
        public Expression<Func<TEntity, bool>> Predicate { get; set; }

        public AndSpecificationAsync(ISpecificationAsync<TEntity> left, ISpecificationAsync<TEntity> right)
        {
            LeftSpecification = left ?? throw new ArgumentNullException(nameof(left));
            RightSpecification = right ?? throw new ArgumentNullException(nameof(right));
        }

        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await LeftSpecification.IsSatisfiedByAsync(candidate) && await RightSpecification.IsSatisfiedByAsync(candidate);
        }
    }
}