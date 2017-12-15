namespace EasySpecificationValidator.Specification
{
    public class LogicalOrSpecification<TEntity> : SpecificationBase<TEntity>
    {
        /// <inheritdoc />
        public LogicalOrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right) 
            : base(left, right) { }

        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) | RightSpecification.IsSatisfiedBy(candidate);
        }
    }
}