using EasySpecificationValidator.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace EasySpcificationValidator.Tests.Specification
{
    public class NotSpecificationAsyncTests : BaseTestAsync<char>
    {
        [TestCleanup]
        public void TestCleanup()
        {
            ClearFakes();
        }

        [TestMethod]
        public async Task NotTheResults()
        {
            SetLeftAndRightExpressionsResults(true, false);

            var leftNottedSpecification = LeftSpecificationAsync.NotAsync();
            leftNottedSpecification.Should().NotBeNull();

            var isLeftValid = await leftNottedSpecification.IsSatisfiedByAsync('A');
            isLeftValid.Should().BeFalse();

            var rightNottedSpecification = RightSpecificationAsync.NotAsync();
            rightNottedSpecification.Should().NotBeNull();

            var isRightValid = await rightNottedSpecification.IsSatisfiedByAsync('Z');
            isRightValid.Should().BeTrue();

            CheckCallTosOfLeftAndRightExpressions(Repeated.Exactly.Once, Repeated.Exactly.Once);
        }
    }
}
