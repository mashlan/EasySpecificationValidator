using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcificationValidator.Tests.Specification
{
    public class NotSpecificationTests
    {
        [TestClass]
        public class MethodsTests : BaseTest<char>
        {
            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void NotTheResults()
            {
                SetLeftAndRightExpressionsResults(true, false);

                var leftNottedSpecification = LeftSpecification.Not();
                leftNottedSpecification.Should().NotBeNull();

                var isLeftValid = leftNottedSpecification.IsSatisfiedBy('A');
                isLeftValid.Should().BeFalse();

                var rightNottedSpecification = RightSpecification.Not();
                rightNottedSpecification.Should().NotBeNull();

                var isRightValid = rightNottedSpecification.IsSatisfiedBy('Z');
                isRightValid.Should().BeTrue();

                CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
            }
        }
    }
}
