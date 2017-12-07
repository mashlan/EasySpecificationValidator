using System;
using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Tests.Samples.Entities;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Specification
{
    public class AndSpecificationTests
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
                var specification = new AndSpecification<int>(fakeSpecification, fakeSpecification);

                specification.Should().NotBeNull();
                specification.Should().BeAssignableTo<ISpecification<int>>();
                specification.Should().BeOfType<AndSpecification<int>>();

                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new AndSpecification<int>(null, fakeSpecification);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: left");
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new AndSpecification<int>(fakeSpecification, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: right");
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
