namespace EasySpecificationValidator.Validator
{
    public interface IValidator<in TEntity>
    {
        bool IsValid(TEntity entity);
    }
}
