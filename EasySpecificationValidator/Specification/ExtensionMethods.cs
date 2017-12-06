using System;

namespace EasySpecificationValidator.Specification
{
    public static class ExtensionMethods
    {
        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> self,
                                                           ISpecification<TEntity> andSpecification)
        {
            return new AndSpecification<TEntity>(self, andSpecification);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> self,
                                                          ISpecification<TEntity> orSpecification)
        {
            return new OrSpecification<TEntity>(self, orSpecification);
        }

        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> self)
        {
            return new NotSpecification<TEntity>(self);
        }
        
        public static ISpecificationAsync<TEntity> AndAsync<TEntity>(this ISpecificationAsync<TEntity> self,
                                                                     ISpecificationAsync<TEntity> andSpecificationAsync)
        {
            return new AndSpecificationAsync<TEntity>(self, andSpecificationAsync);
        }

        public static ISpecificationAsync<TEntity> OrAsync<TEntity>(this ISpecificationAsync<TEntity> self,
                                                                    ISpecificationAsync<TEntity> orSpecificationAsync)
        {
            return new OrSpecificationAsync<TEntity>(self, orSpecificationAsync);
        }

        public static ISpecificationAsync<TEntity> NotAsync<TEntity>(this ISpecificationAsync<TEntity> self)
        {
            return new NotSpecificationAsync<TEntity>(self);
        }
    }
}