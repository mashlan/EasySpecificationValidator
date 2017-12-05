using EasySpecification.Specification;

namespace EasySpecification.Validator
{
    public abstract class GenericValidator<TEntity> : IValidator<TEntity>
    {
        public abstract GenericSpecification<TEntity> Specification { get; set; }

        public virtual bool IsValid(TEntity entity)
        {
            return Specification.IsSatisfiedBy(entity);
        }
    }
}