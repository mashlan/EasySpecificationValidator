using System.Threading.Tasks;

namespace EasySpecificationValidator.Validator
{
    public interface IValidatorAsync<in TEntity>
    {
        Task<bool> IsValidAsync(TEntity entity);
    }
}