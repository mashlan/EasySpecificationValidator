using System;
using EasySpecification.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcification.Tests.Specification
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
    }
}
