namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class OrSpecification<TEntity> : SpecificationBase<TEntity>
    {
        /// <inheritdoc />
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right) 
            : base(left, right){ }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) || RightSpecification.IsSatisfiedBy(candidate);
        }
    }
}