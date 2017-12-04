using System.Threading.Tasks;
using EasySpecification.Rule;

namespace EasySpecification.Validator
{
    public interface IValidatorAsync<in TEntity> where TEntity : class
    {
        Task<bool> IsValidAsync(params IRule<TEntity>[] rules);
    }
}