using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EasySpecificationValidator.Tests.Specification
{
    public class OrSpecificationTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecification<int> fakeSpecification;
            private readonly OrSpecification<int> specification;

            public ConstructorTests()
            {
                fakeSpecification = A.Fake<ISpecification<int>>();
                specification = new OrSpecification<int>(fakeSpecification, fakeSpecification);
            }

            [TestMethod]
            public void InheritsFromISpecification()
            {
                specification.Should().BeAssignableTo<ISpecification<int>>();
            }

            [TestMethod]
            public void RuleShouldBeNull()
            {
                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new OrSpecification<int>(null, fakeSpecification);

                ctor.Should().Throw<ArgumentNullException>()
                    .WithMessage(ExceptionUtilities.ArgumentNullExceptionMessage("left"));
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new OrSpecification<int>(fakeSpecification, null);

                ctor.Should().Throw<ArgumentNullException>()
                    .WithMessage(ExceptionUtilities.ArgumentNullExceptionMessage("right"));
            }
        }

        [TestClass]
        public class MethodsTests : BaseTest<string>
        {
            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void OrLeftAndRightSideAreTrue()
            {
                SetLeftAndRightExpressionsResults(true, true);

                var isValid = LeftSpecification.Or(RightSpecification).IsSatisfiedBy(A.Dummy<string>());
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public void OrLeftIsTrueOnly()
            {
                SetLeftAndRightExpressionsResults(true, false);

                var isValid = LeftSpecification.Or(RightSpecification).IsSatisfiedBy(A.Dummy<string>());
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public void OrRightIsTrueOnly()
            {
                SetLeftAndRightExpressionsResults(false, true);

                var isValid = LeftSpecification.Or(RightSpecification).IsSatisfiedBy(A.Dummy<string>());
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public void OrLeftAndRightSideAreFalse()
            {
                SetLeftAndRightExpressionsResults(false, false);

                var isValid = LeftSpecification.Or(RightSpecification).IsSatisfiedBy(A.Dummy<string>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }
        }
    }
}
