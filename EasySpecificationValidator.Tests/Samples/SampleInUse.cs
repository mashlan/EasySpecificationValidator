using System;
using System.Threading.Tasks;
using EasySpecificationValidator.Tests.Samples.Entities;
using EasySpecificationValidator.Tests.Samples.Validator;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Samples
{
    [TestClass]
    public class SampleInUse
    {
        private readonly PersonValidatorAsync validator;

        public SampleInUse()
        {
            validator = new PersonValidatorAsync();
        }

        [TestMethod]
        [Description("This person is under the age of 18, so validation fails.")]
        public async Task IsUnder18Fail()
        {
            var under18Person = new Person { Age = 17, BirthDate = DateTime.Now.AddYears(-17) };

            var isValid = await validator.IsValidAsync(under18Person);
            isValid.Should().BeFalse();
        }

        [TestMethod]
        [Description("This person is over the age of 18 but is born in September.")]
        public async Task IsBornInSeptemberFail()
        {
            var personBornInSept = new Person { Age = 35, BirthDate = new DateTime(1982, 9, 1) };

            var isValid = await validator.IsValidAsync(personBornInSept);
            isValid.Should().BeFalse();
        }

        [TestMethod]
        [Description("This person is over the age of 18 and is not born in September.")]
        public async Task ValidPerson()
        {
            var validPerson = new Person { Age = 35, BirthDate = new DateTime(1982, 11, 11) };

            var isValid = await validator.IsValidAsync(validPerson);
            isValid.Should().BeTrue();
        }
    }
}
