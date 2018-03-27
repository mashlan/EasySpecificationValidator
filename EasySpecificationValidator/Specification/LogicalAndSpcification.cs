namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class LogicalAndSpcification<TEntity> : SpecificationBase<TEntity>
    {
        /// <inheritdoc />
        public LogicalAndSpcification(ISpecification<TEntity> left, ISpecification<TEntity> right) 
            : base(left, right) { }

        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) & RightSpecification.IsSatisfiedBy(candidate);
        }
        
    }
}