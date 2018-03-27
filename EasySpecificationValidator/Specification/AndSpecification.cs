namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class AndSpecification<TEntity> : SpecificationBase<TEntity>
    {
        /// <inheritdoc />
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(left, right) { }

        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) && RightSpecification.IsSatisfiedBy(candidate);
        }
    }
}