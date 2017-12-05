namespace EasySpecification.Specification
{
    public static class ExtensionMethods
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> spec1,
            ISpecification<TEntity> spec2)
        {
            return new AndSpecification<TEntity>(spec1, spec2);
        }

        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> spec1,
            ISpecification<TEntity> spec2)
        {
            return new OrSpecification<TEntity>(spec1, spec2);
        }

        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> spec)
        {
            return new NotSpecification<TEntity>(spec);
        }
        
        public static ISpecificationAsync<TEntity> AndAsync<TEntity>(this ISpecificationAsync<TEntity> spec1,
            ISpecificationAsync<TEntity> spec2)
        {
            return new AndSpecificationAsync<TEntity>(spec1, spec2);
        }

        public static ISpecificationAsync<TEntity> OrAsync<TEntity>(this ISpecificationAsync<TEntity> spec1,
            ISpecificationAsync<TEntity> spec2)
        {
            return new OrSpecificationAsync<TEntity>(spec1, spec2);
        }

        public static ISpecificationAsync<TEntity> NotAsync<TEntity>(this ISpecificationAsync<TEntity> spec)
        {
            return new NotSpecificationAsync<TEntity>(spec);
        }
    }
}