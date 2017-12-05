using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public class AndSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        public AndSpecificationAsync(ISpecificationAsync<TEntity> spec1, ISpecificationAsync<TEntity> spec2)
        {
            Spec1 = spec1 ?? throw new ArgumentNullException(nameof(spec1));
            Spec2 = spec2 ?? throw new ArgumentNullException(nameof(spec2));
        }

        private ISpecificationAsync<TEntity> Spec1 { get; }
        private ISpecificationAsync<TEntity> Spec2 { get; }

        public Func<Task<bool>> Rule => null;

        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await Spec1.IsSatisfiedByAsync(candidate) && await Spec2.IsSatisfiedByAsync(candidate);
        }

        public Expression<Func<TEntity, bool>> Predicate { get; set; }
    }
}