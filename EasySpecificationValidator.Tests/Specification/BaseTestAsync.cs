using EasySpecificationValidator.Specification;
using FakeItEasy;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasySpcificationValidator.Tests.Specification
{
    public class BaseTestAsync<TSpecificationEntity>
    {
        protected readonly ISpecificationAsync<TSpecificationEntity> LeftSpecificationAsync;
        protected readonly ISpecificationAsync<TSpecificationEntity> RightSpecificationAsync;

        protected readonly Expression<Func<Task<bool>>> LeftSpecExpressionIsSatisfiedBy;
        protected readonly Expression<Func<Task<bool>>> RightSpecExpressionIsSatisfiedBy;

        public BaseTestAsync()
        {
            LeftSpecificationAsync = A.Fake<ISpecificationAsync<TSpecificationEntity>>();
            RightSpecificationAsync = A.Fake<ISpecificationAsync<TSpecificationEntity>>();

            LeftSpecExpressionIsSatisfiedBy = () => LeftSpecificationAsync.IsSatisfiedByAsync(A<TSpecificationEntity>.Ignored);
            RightSpecExpressionIsSatisfiedBy = () => RightSpecificationAsync.IsSatisfiedByAsync(A<TSpecificationEntity>.Ignored);
        }

        protected void SetLeftAndRightExpressionsResults(bool leftResult, bool rightResult)
        {
            A.CallTo(LeftSpecExpressionIsSatisfiedBy).Returns(leftResult);
            A.CallTo(RightSpecExpressionIsSatisfiedBy).Returns(rightResult);
        }

        protected void CheckCallTosOfLeftAndRightExpressions(Repeated leftCallCount, Repeated rightCallCount)
        {
            A.CallTo(LeftSpecExpressionIsSatisfiedBy).MustHaveHappened(leftCallCount);
            A.CallTo(RightSpecExpressionIsSatisfiedBy).MustHaveHappened(rightCallCount);
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(LeftSpecificationAsync);
            Fake.ClearConfiguration(RightSpecificationAsync);
        }
    }
}
