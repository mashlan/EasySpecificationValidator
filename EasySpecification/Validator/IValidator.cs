namespace EasySpecification.Validator
{
    public interface IValidator<in TEntity>
    {
        bool IsValid(TEntity entity);
    }
}
