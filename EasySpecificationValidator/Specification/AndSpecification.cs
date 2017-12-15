namespace EasySpecificationValidator.Specification
{
    public class AndSpecification<TEntity> : SpecificationBase<TEntity>
    { 
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(left, right) { }

        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) && RightSpecification.IsSatisfiedBy(candidate);
        }
    }
}