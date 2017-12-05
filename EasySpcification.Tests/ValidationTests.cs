using System;
using EasySpcification.Tests.Entities;
using EasySpcification.Tests.Validators;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcification.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateOne()
        {
            var entity = GetTestEntity();
            var validator = new TestEntityValidatorSingleRule();
            var isValid = validator.IsValid(entity);

            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void ValidateTwo()
        {
            var entity = GetTestEntity();
            var validator = new TestEntityValidatorMultipleRules();
            var isValid = validator.IsValid(entity);

            isValid.Should().BeTrue();
        }

        private static TestEntity GetTestEntity()
        {
            return new TestEntity
            {
                Age = 19,
                BirthDate = DateTime.Now.AddYears(-20).Date,
                Email = "test.email@mail.com",
                FirstName = "Test",
                LastName = "User"
            };
        }
    }
}
