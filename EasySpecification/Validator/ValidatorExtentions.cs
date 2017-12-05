namespace EasySpecification.Validator
{
    public static class ValidatorExtentions
    {
        public static bool IsValid<TEntity>(this ICanValidate<TEntity> entity) where TEntity : class
        {
            //var validator = GetValidator(typeof(T));
            //return validator.IsValid(entity);
            return true;
        }
    }
}