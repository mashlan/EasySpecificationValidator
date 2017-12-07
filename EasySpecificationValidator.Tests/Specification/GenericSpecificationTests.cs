using System;
using EasySpecificationValidator.Specification;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Specification
{
    public class GenericSpecificationTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var genericSpecification = new MockGenericSpecification();

                genericSpecification.Should().NotBeNull();
                genericSpecification.Should().BeAssignableTo<ISpecification<string>>();
                genericSpecification.Should().BeAssignableTo<GenericSpecification<string>>();
                genericSpecification.Should().BeOfType<MockGenericSpecification>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly MockGenericSpecification mockGenericSpecification;

            public MethodsTests()
            {
                mockGenericSpecification = new MockGenericSpecification();
            }

            [DataTestMethod]
            [DataRow(null)]
            [DataRow("")]
            [DataRow("  ")]
            public void IsInvalid(string value)
            {
                var isValid = mockGenericSpecification.IsSatisfiedBy(value);
                isValid.Should().BeFalse();
            }

            [TestMethod]
            public void IsValid()
            {
                var isValid = mockGenericSpecification.IsSatisfiedBy("I'm valid n' stuff.");
                isValid.Should().BeTrue();
            }
        }

        internal class MockGenericSpecification : GenericSpecification<string>
        {
            #region Overrides of GenericSpecification<TEntity>

            public override Func<string, bool> Rule => value => !string.IsNullOrWhiteSpace(value);

            #endregion
        }
    }
}
