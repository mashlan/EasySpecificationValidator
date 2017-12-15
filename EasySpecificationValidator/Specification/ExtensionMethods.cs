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
        public static ISpecification<TEntity> LogicalAnd<TEntity>(this ISpecification<TEntity> self,
            ISpecification<TEntity> logicalAndSpecification)
        {
            return new LogicalAndSpcification<TEntity>(self, logicalAndSpecification);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> self,
                                                          ISpecification<TEntity> orSpecification)
        {
            return new OrSpecification<TEntity>(self, orSpecification);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecification<TEntity> LogicalOr<TEntity>(this ISpecification<TEntity> self,
            ISpecification<TEntity> logicalOrSpecification)
        {
            return new LogicalOrSpecification<TEntity>(self, logicalOrSpecification);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> self)
        {
            return new NotSpecification<TEntity>(self);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecificationAsync<TEntity> AndAsync<TEntity>(this ISpecificationAsync<TEntity> self,
                                                                     ISpecificationAsync<TEntity> andSpecificationAsync)
        {
            return new AndSpecificationAsync<TEntity>(self, andSpecificationAsync);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecificationAsync<TEntity> LogicalAndAsync<TEntity>(this ISpecificationAsync<TEntity> self,
            ISpecificationAsync<TEntity> logicalAndSpecificationAsync)
        {
            return new LogicalAndSpecificationAsync<TEntity>(self, logicalAndSpecificationAsync);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecificationAsync<TEntity> LogicalOrAsync<TEntity>(this ISpecificationAsync<TEntity> self,
            ISpecificationAsync<TEntity> logicalOrSpecificationAsync)
        {
            return new LogicalOrSpecificationAsync<TEntity>(self, logicalOrSpecificationAsync);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecificationAsync<TEntity> OrAsync<TEntity>(this ISpecificationAsync<TEntity> self,
                                                                    ISpecificationAsync<TEntity> orSpecificationAsync)
        {
            return new OrSpecificationAsync<TEntity>(self, orSpecificationAsync);
        }

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public static ISpecificationAsync<TEntity> NotAsync<TEntity>(this ISpecificationAsync<TEntity> self)
        {
            return new NotSpecificationAsync<TEntity>(self);
        }
    }
}