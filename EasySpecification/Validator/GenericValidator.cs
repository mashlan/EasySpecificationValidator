using System;
using EasySpecification.Specification;

namespace EasySpecification.Validator
{
    public abstract class GenericValidator<TEntity> : IValidator<TEntity>
    {
        public abstract GenericSpecification<TEntity> Specification { get; set; }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public virtual bool IsValid(TEntity entity)
        {
            return Specification.IsSatisfiedBy(entity);
        }
    }
}