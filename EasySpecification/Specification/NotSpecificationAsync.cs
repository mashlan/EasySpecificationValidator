using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpecification.Specification
{
    public class NotSpecificationAsync<TEntity> : ISpecificationAsync<TEntity>
    {
        internal NotSpecificationAsync(ISpecificationAsync<TEntity> spec)
        {
            Spec = spec ?? throw new ArgumentNullException(nameof(spec));
        }

        private ISpecificationAsync<TEntity> Spec { get; }

        public Func<Task<bool>> Rule => null;

        public async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return !(await Spec.IsSatisfiedByAsync(candidate));
        }
    }
}