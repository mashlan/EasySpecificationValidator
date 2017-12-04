using System;

namespace EasySpecification.Rule
{
    public interface IRule<in TEntity> where TEntity: class
    {
        Func<TEntity, bool> Create<T>(T value);
    }

    public static class RuleExtentions
    {
        public static IRule<TEntity> CreateRule<TEntity>(this IRule<TEntity> rule) where TEntity : class
        {
            return new Rule<TEntity>();
        }
    }

    public class Rule<TEntity> : IRule<TEntity> where TEntity : class
    {
        public Func<TEntity, bool> Create<T>(T value)
        {
            throw new NotImplementedException();
        }
    }
}
