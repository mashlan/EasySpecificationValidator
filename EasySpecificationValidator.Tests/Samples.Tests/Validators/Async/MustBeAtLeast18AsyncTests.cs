using System.Threading.Tasks;
using EasySpcificationValidator.Tests.Samples.Entities;
using EasySpcificationValidator.Tests.Samples.Validators.Person.Async;
using EasySpecificationValidator.Specification;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcificationValidator.Tests.Samples.Tests.Validators.Async
{
    public class MustBeAtLeast18AsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritece()
            {
                var validator = new MustBeAtLeast18Async();

                validator.Should().NotBeNull();
                validator.Should().BeAssignableTo<ISpecificationAsync<Person>>();
                validator.Should().BeAssignableTo<GenericSpecificationAsync<Person>>();
                validator.Should().BeOfType<MustBeAtLeast18Async>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly MustBeAtLeast18Async validator;

            public MethodsTests()
            {
                validator = new MustBeAtLeast18Async();
            }

            [TestMethod]
            public async Task IsInvalid()
            {
                var notOldEnoughPerson = new Person { Age = 6 };

                var isValid = await validator.IsSatisfiedByAsync(notOldEnoughPerson);
                isValid.Should().BeFalse();
            }

            [TestMethod]
            public async Task IsValid()
            {
                var oldEnoughPerson = new Person { Age = 19 };

                var isValid = await validator.IsSatisfiedByAsync(oldEnoughPerson);
                isValid.Should().BeTrue();
            }
        }
    }
}
