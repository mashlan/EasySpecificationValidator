using EasySpecification.Rule;

namespace EasySpecification.Validator
{
    public interface IValidator<in TEntity> where TEntity : class
    {
        bool IsValid(params IRule<TEntity>[] rules);
    }
}
