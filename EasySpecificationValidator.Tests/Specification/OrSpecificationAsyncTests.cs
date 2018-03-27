using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Specification
{
    public class OrSpecificationAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecificationAsync<int> fakeSpecification;
            private readonly OrSpecificationAsync<int> specificationAsync;

            public ConstructorTests()
            {
                fakeSpecification = A.Fake<ISpecificationAsync<int>>();
                specificationAsync = new OrSpecificationAsync<int>(fakeSpecification, fakeSpecification);
            }

            [TestMethod]
            public void InheritsFromISpecificationAsync()
            {
                specificationAsync.Should().BeAssignableTo<ISpecificationAsync<int>>();
            }

            [TestMethod]
            public void RuleShouldBeNull()
            {
                specificationAsync.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new OrSpecificationAsync<int>(null, fakeSpecification);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: left");
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new OrSpecificationAsync<int>(fakeSpecification, null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
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
