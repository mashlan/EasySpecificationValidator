using System;
using System.Threading.Tasks;

namespace EasySpecification.Rule
{
    public interface IRuleAsync<TEntity> where TEntity: class
    {
        Task<Func<TEntity>> ValidateAsync();
    }
}