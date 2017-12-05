using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public class OrSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        public OrSpecificationAsync(ISpecificationAsync<TEntity> spec1, ISpecificationAsync<TEntity> spec2)
        {
            Spec1 = spec1 ?? throw new ArgumentNullException(nameof(spec1));
            Spec2 = spec2 ?? throw new ArgumentNullException(nameof(spec2));
        }

        private ISpecificationAsync<TEntity> Spec1 { get; }
        private ISpecificationAsync<TEntity> Spec2 { get; }

        public Expression<Func<TEntity, bool>> Rule => null;

        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await Spec1.IsSatisfiedByAsync(candidate) || await Spec2.IsSatisfiedByAsync(candidate);
        }
    }
}