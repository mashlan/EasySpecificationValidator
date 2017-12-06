using EasySpecification.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EasySpcification.Tests.Specification
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
    }
}
