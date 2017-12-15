using System;
using System.Linq.Expressions;
using EasySpecificationValidator.Specification;
using FakeItEasy;

namespace EasySpecificationValidator.Tests.Specification
{
    public class BaseTest<TSpecificationEntity>
    {
        protected readonly ISpecification<TSpecificationEntity> LeftSpecification;
        protected readonly ISpecification<TSpecificationEntity> RightSpecification;

        protected readonly Expression<Func<bool>> LeftSpecExpressionIsSatisfiedBy;
        protected readonly Expression<Func<bool>> RightSpecExpressionIsSatisfiedBy;

        public BaseTest()
        {
            LeftSpecification = A.Fake<ISpecification<TSpecificationEntity>>();
            RightSpecification = A.Fake<ISpecification<TSpecificationEntity>>();

            LeftSpecExpressionIsSatisfiedBy = () => LeftSpecification.IsSatisfiedBy(A<TSpecificationEntity>.Ignored);
            RightSpecExpressionIsSatisfiedBy = () => RightSpecification.IsSatisfiedBy(A<TSpecificationEntity>.Ignored);
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
            Fake.ClearConfiguration(LeftSpecification);
            Fake.ClearConfiguration(RightSpecification);
        }
    }
}
