using System;
using EasySpecification.Specification;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcification.Tests.Specification
{
    public class AndSpecificationTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly ISpecification<int> fakeSpecification;

            public ConstructorTests()
            {
                fakeSpecification = A.Fake<ISpecification<int>>();
            }

            [TestMethod]
            public void Inheritence()
            {
                var specification = new AndSpecification<int>(fakeSpecification, fakeSpecification);

                specification.Should().NotBeNull();
                specification.Should().BeAssignableTo<ISpecification<int>>();
                specification.Should().BeOfType<AndSpecification<int>>();

                specification.Rule.Should().BeNull();
            }

            [TestMethod]
            public void LeftSpecificationIsNull()
            {
                Action ctor = () => new AndSpecification<int>(null, fakeSpecification);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: left");
            }

            [TestMethod]
            public void RightSpecificationIsNull()
            {
                Action ctor = () => new AndSpecification<int>(fakeSpecification, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: right");
            }
        }
    }
}
