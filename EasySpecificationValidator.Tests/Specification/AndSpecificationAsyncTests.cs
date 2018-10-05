using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Tests.Specification
{
    public class AndSpecificationAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecificationAsync<int> fakeSpecificationAsync;
            private readonly AndSpecificationAsync<int> specification;

            public ConstructorTests()
            {
                fakeSpecificationAsync = A.Fake<ISpecificationAsync<int>>();
                specification = new AndSpecificationAsync<int>(fakeSpecificationAsync, fakeSpecificationAsync);
            }

            [TestMethod]
            public void InheritsFromISpecificationAsync()
            {
                specification.Should().BeAssignableTo<ISpecificationAsync<int>>();
            }

            [TestMethod]
            public void RuleShouldBeNull()
            {
                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new AndSpecificationAsync<int>(null, fakeSpecificationAsync);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionUtilities.ArgumentNullExceptionMessage("left"));
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new AndSpecificationAsync<int>(fakeSpecificationAsync, null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionUtilities.ArgumentNullExceptionMessage("right"));
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

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync(A.Dummy<string>());
                isValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public async Task RightSpecificationIsFalse()
            {
                SetLeftAndRightExpressionsResults(true, false);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync(A.Dummy<string>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }

            [TestMethod]
            public async Task LeftSpecificationIsFalse()
            {
                SetLeftAndRightExpressionsResults(false, true);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync(A.Dummy<string>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }

            [TestMethod]
            public async Task BothAndedSpecificationAreFalse()
            {
                SetLeftAndRightExpressionsResults(false, false);

                var isValid = await LeftSpecificationAsync.AndAsync(RightSpecificationAsync).IsSatisfiedByAsync(A.Dummy<string>());
                isValid.Should().BeFalse();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Never);
            }
        }
    }
}
