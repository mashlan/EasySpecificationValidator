using System.Threading.Tasks;

namespace EasySpecificationValidator.Specification
{
    /// <inheritdoc />
    public class LogicalOrSpecificationAsync<TEntity>: SpecificationBaseAsync<TEntity>
    {
        /// <inheritdoc />
        public LogicalOrSpecificationAsync(ISpecificationAsync<TEntity> left, ISpecificationAsync<TEntity> right) 
            : base(left, right) { }

        #region Overrides of SpecificationBaseAsync<TEntity>

        /// <inheritdoc />
        public override async Task<bool> IsSatisfiedByAsync(TEntity candidate)
        {
            return await LeftSpecification.IsSatisfiedByAsync(candidate) || await RightSpecification.IsSatisfiedByAsync(candidate);
        }

        #endregion
    }
}