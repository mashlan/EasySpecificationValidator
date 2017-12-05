using System.Threading.Tasks;

namespace EasySpecification.Validator
{
    public interface IValidatorAsync<in TEntity> where TEntity : class
    {
        Task<bool> IsValidAsync(TEntity entity);
    }
}