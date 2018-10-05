using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Tests.Samples.Entities;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EasySpecificationValidator.Tests.Specification
{
    public class AndSpecificationTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecification<int> fakeSpecification;
            private readonly AndSpecification<int> specification;

            public ConstructorTests()
            {
                fakeSpecification = A.Fake<ISpecification<int>>();
                specification = new AndSpecification<int>(fakeSpecification, fakeSpecification);
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
                Action ctor = () => new AndSpecification<int>(null, fakeSpecification);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionUtilities.ArgumentNullExceptionMessage("left"));
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new AndSpecification<int>(fakeSpecification, null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionUtilities.ArgumentNullExceptionMessage("right"));
            }
        }

        [TestClass]
        public class MethodsTests : BaseTest<Person>
        {
            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void BothAndedSpecificationsAreTrue()
            {
                SetLeftAndRightExpressionsResults(true, true);

                var isValid = LeftSpecification.And(RightSpecification).IsSatisfiedBy(A.Dummy<Person>());
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public void RightSpecificationIsFalse()
            {
                SetLeftAndRightExpressionsResults(true, false);

                var isValid = LeftSpecification.And(RightSpecification).IsSatisfiedBy(A.Dummy<Person>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public void LeftSpecificationIsFalse()
            {
                SetLeftAndRightExpressionsResults(false, true);

                var isValid = LeftSpecification.And(RightSpecification).IsSatisfiedBy(A.Dummy<Person>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public void BothAndedSpecificationAreFalse()
            {
                SetLeftAndRightExpressionsResults(false, false);

                var isValid = LeftSpecification.And(RightSpecification).IsSatisfiedBy(A.Dummy<Person>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }
        }
    }
}
