using System;

namespace EasySpecification.Validator
{
    public abstract class AbstractValidatorLocator
    {
        protected readonly IServiceProvider ServiceProvider;

        protected AbstractValidatorLocator(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public virtual IValidatorAsync<TEntity> GetValidator<TEntity>() where TEntity : class
        {
            return (IValidatorAsync<TEntity>)ServiceProvider.GetService(typeof(IValidatorAsync<TEntity>));
        }
    }
}