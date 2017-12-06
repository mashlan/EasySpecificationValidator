using System;
using System.Threading.Tasks;
using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcificationValidator.Tests.Specification
{
    public class AndSpecificationAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecificationAsync<int> fakeSpecificationAsync;

            public ConstructorTests()
            {
                fakeSpecificationAsync = A.Fake<ISpecificationAsync<int>>();
            }

            [TestMethod]
            public void Inheritence()
            {
                var specification = new AndSpecificationAsync<int>(fakeSpecificationAsync, fakeSpecificationAsync);

                specification.Should().NotBeNull();
                specification.Should().BeAssignableTo<ISpecificationAsync<int>>();
                specification.Should().BeOfType<AndSpecificationAsync<int>>();

                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new AndSpecificationAsync<int>(null, fakeSpecificationAsync);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: left");
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new AndSpecificationAsync<int>(fakeSpecificationAsync, null);

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
            public async Task BothAndedSpecificationsAreTrue()
            {
                SetLeftAndRightExpressionsResults(true, true);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync("Wolverine");
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public async Task RightSpecificationIsFalse()
            {
                SetLeftAndRightExpressionsResults(true, false);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync("Jason Voorhees");
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public async Task LeftSpecificationIsFalse()
            {
                SetLeftAndRightExpressionsResults(false, true);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync("Wade Wilson");
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public async Task BothAndedSpecificationAreFalse()
            {
                SetLeftAndRightExpressionsResults(false, false);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync("Clark Kent");
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }
        }
    }
}
