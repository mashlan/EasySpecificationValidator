using System;
using EasySpecificationValidator.Tests.Samples.Entities;
using EasySpecificationValidator.Tests.Samples.Specifications.Person;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Validator
{
    [TestClass]
    public class ValidatorTests
    {
        private TestEntityValidatorMultipleRules validator;
        private TestEntityValidatorMultipleLogicalRules logicalValidator;

        [TestInitialize]
        public void Init()
        {
            validator = new TestEntityValidatorMultipleRules();
            logicalValidator = new TestEntityValidatorMultipleLogicalRules();
        }

        [TestMethod]
        public void NameLengthShouldBeValid()
        {
            var person = GetTestPerson(firstName: "FirstName");
            var isValid = validator.IsValid(person);
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void NameLengthShouldNotBeValid()
        {
            var person = GetTestPerson(firstName: "thisisaveryverylongfirstnamebuddy");
            var isValid = validator.IsValid(person);
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void NameIsEmpty()
        {
            var person = GetTestPerson(firstName: string.Empty);
            var isValid = validator.IsValid(person);
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void PersonShouldBeValid()
        {
            var person = GetTestPerson();
            var isValid = logicalValidator.IsValid(person);
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void PersonShouldHaveMultipleErrorChecks()
        {
            // The difference between this test and the one below is that all rules are checked.
            var person = GetTestPerson(
                age: 12,
                firstName: string.Empty, 
                lastName: "valid",
                birthDate: DateTime.Now.AddYears(-10));

            var isValid = logicalValidator.IsValid(person);
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void PersonShouldHaveSingleeErrorCheck()
        {
            //This will fail on the first rule
            var person = GetTestPerson(
                age: 12,
                firstName: string.Empty,
                lastName: "valid",
                birthDate: DateTime.Now.AddYears(-10));

            var isValid = validator.IsValid(person);
            isValid.Should().BeFalse();
        }

        /// <summary>
        /// Create a new Test User. Override default values as needed
        /// </summary>
        private static Person GetTestPerson(
            int? age = null,
            DateTime? birthDate = null, 
            string email = null,
            string firstName = null,
            string lastName = null)
        {
            return new Person
            {
                Age = age ?? 21,
                BirthDate = birthDate ?? DateTime.Now.AddYears(-21),
                Email = email ?? "test.user@test.com",
                FirstName = firstName ?? "Test",
                LastName = lastName ?? "User"
            };
        }
    }
}
