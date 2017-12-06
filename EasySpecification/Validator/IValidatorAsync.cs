using System.Threading.Tasks;

namespace EasySpecification.Validator
{
    public interface IValidatorAsync<in TEntity>
    {
        Task<bool> IsValidAsync(TEntity entity);
    }
}