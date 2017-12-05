using EasySpcification.Tests.Samples.Entities;
using EasySpcification.Tests.Samples.Validators.Person;
using EasySpecification.Specification;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcification.Tests.Samples.Tests.Validators
{
    public class FirstNameCannotBeGreaterThanTwentyFiveTestsTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var validator = new FirstNameCannotBeGreaterThanTwentyFive();

                validator.Should().NotBeNull();
                validator.Should().BeAssignableTo<ISpecification<Person>>();
                validator.Should().BeAssignableTo<GenericSpecification<Person>>();
                validator.Should().BeOfType<FirstNameCannotBeGreaterThanTwentyFive>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly FirstNameCannotBeGreaterThanTwentyFive validator;

            public MethodsTests()
            {
                validator = new FirstNameCannotBeGreaterThanTwentyFive();
            }

            [TestMethod]
            public void IsInvalid()
            {
                var entity = new Person{ FirstName = "LessThan25" };

                var isValid = validator.IsSatisfiedBy(entity);

                isValid.Should().BeTrue();
            }

            [TestMethod]
            public void IsValid()
            {
                var entity = new Person{ FirstName = "I am a really long first name or something that is totally passed the 25 character limit."};

                var isValid = validator.IsSatisfiedBy(entity);

                isValid.Should().BeFalse();
            }
        }
    }
}
