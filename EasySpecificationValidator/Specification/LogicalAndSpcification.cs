namespace EasySpecificationValidator.Specification
{
    public class LogicalAndSpcification<TEntity> : SpecificationBase<TEntity>
    {
        public LogicalAndSpcification(ISpecification<TEntity> left, ISpecification<TEntity> right) 
            : base(left, right) { }

        /// <inheritdoc />
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return LeftSpecification.IsSatisfiedBy(candidate) & RightSpecification.IsSatisfiedBy(candidate);
        }
        
    }
}