using System;
using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Specification
{
    public class OrSpecificationTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecification<int> fakeSpecification;

            public ConstructorTests()
            {
                fakeSpecification = A.Fake<ISpecification<int>>();
            }

            [TestMethod]
            public void Inheritence()
            {
                var specification = new OrSpecification<int>(fakeSpecification, fakeSpecification);

                specification.Should().NotBeNull();
                specification.Should().BeAssignableTo<ISpecification<int>>();
                specification.Should().BeOfType<OrSpecification<int>>();

                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new OrSpecification<int>(null, fakeSpecification);

                ctor.Should().Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: left");
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new OrSpecification<int>(fakeSpecification, null);

                ctor.Should().Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: right");
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
