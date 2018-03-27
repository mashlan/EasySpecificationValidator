using System;
using System.Threading.Tasks;
using EasySpecificationValidator.Specification;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Specification
{
    public class GenericSpecificationAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly MockGenericSpecificationAsync genericSpecification;

            public ConstructorTests()
            {
                genericSpecification = new MockGenericSpecificationAsync();
            }

            [TestMethod]
            public void InheritsFromISpecificationAsync()
            {
                genericSpecification.Should().BeAssignableTo<ISpecificationAsync<string>>();
            }

            [TestMethod]
            public void InheritsFromGenericSpecificationAsync()
            {
                genericSpecification.Should().BeAssignableTo<GenericSpecificationAsync<string>>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly MockGenericSpecificationAsync mockGenericSpecificationAsync;

            public MethodsTests()
            {
                mockGenericSpecificationAsync = new MockGenericSpecificationAsync();
            }

            [DataTestMethod]
            [DataRow(null)]
            [DataRow("")]
            [DataRow("  ")]
            public async Task IsInvalid(string value)
            {
                var isValid = await mockGenericSpecificationAsync.IsSatisfiedByAsync(value);
                isValid.Should().BeFalse();
            }

            [TestMethod]
            public async Task IsValid()
            {
                var isValid = await mockGenericSpecificationAsync.IsSatisfiedByAsync("I'm valid n' stuff.");
                isValid.Should().BeTrue();
            }
        }

        internal class MockGenericSpecificationAsync : GenericSpecificationAsync<string>
        {
            #region Overrides of GenericSpecification<TEntity>

            public override Func<string, Task<bool>> Rule => value => Task.FromResult(!string.IsNullOrWhiteSpace(value));

            #endregion
        }
    }
}
