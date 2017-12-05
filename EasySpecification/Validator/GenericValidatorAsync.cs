using System.Threading.Tasks;
using EasySpecification.Specification;

namespace EasySpecification.Validator
{
    public abstract class GenericValidatorAsync<TEntity> : IValidatorAsync<TEntity> where TEntity : class
    {
        public abstract GenericSpecificationAsync<TEntity> Specification { get; set; }

        public virtual async Task<bool> IsValidAsync(TEntity entity)
        {
            return await Specification.IsSatisfiedByAsync(entity);
        }
    }
}