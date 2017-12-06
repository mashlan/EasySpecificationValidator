using System;
using System.Threading.Tasks;
using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcificationValidator.Tests.Specification
{
    public class OrSpecificationAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecificationAsync<int> fakeSpecification;

            public ConstructorTests()
            {
                fakeSpecification = A.Fake<ISpecificationAsync<int>>();
            }

            [TestMethod]
            public void Inheritence()
            {
                var specification = new OrSpecificationAsync<int>(fakeSpecification, fakeSpecification);

                specification.Should().NotBeNull();
                specification.Should().BeAssignableTo<ISpecificationAsync<int>>();
                specification.Should().BeOfType<OrSpecificationAsync<int>>();

                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new OrSpecificationAsync<int>(null, fakeSpecification);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: left");
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new OrSpecificationAsync<int>(fakeSpecification, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: right");
            }
        }

        [TestClass]
        public class MethodsTests : BaseTestAsync<string>
        {
            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public async Task OrLeftAndRightSideAreTrue()
            {
                SetLeftAndRightExpressionsResults(true, true);

                var isValid = await LeftSpecificationAsync.OrAsync(RightSpecificationAsync).IsSatisfiedByAsync("Magic");
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public async Task OrLeftIsTrueOnly()
            {
                SetLeftAndRightExpressionsResults(true, false);

                var isValid = await LeftSpecificationAsync.OrAsync(RightSpecificationAsync).IsSatisfiedByAsync("Zeplin");
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public async Task OrRightIsTrueOnly()
            {
                SetLeftAndRightExpressionsResults(false, true);

                var isValid = await LeftSpecificationAsync.OrAsync(RightSpecificationAsync).IsSatisfiedByAsync("Greens n' such.");
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public async Task OrLeftAndRightSideAreFalse()
            {
                SetLeftAndRightExpressionsResults(false, false);

                var isValid = await LeftSpecificationAsync.OrAsync(RightSpecificationAsync).IsSatisfiedByAsync("Deadpool");
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }
        }
    }
}
