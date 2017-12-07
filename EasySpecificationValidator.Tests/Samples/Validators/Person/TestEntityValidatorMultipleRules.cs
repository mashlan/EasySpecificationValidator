using System;
using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Tests.Samples.Validators.Person;
using EasySpecificationValidator.Validator;

namespace EasySpcificationValidator.Tests.Samples.Validators.Person
{
    public class TestEntityValidatorMultipleRules : IValidator<EasySpecificationValidator.Tests.Samples.Entities.Person>
    {
        #region Implementation of IValidator<in Person>

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public bool IsValid(EasySpecificationValidator.Tests.Samples.Entities.Person entity)
        {
            var firstNameNotEmpty = new FirstNameCannotBeNullOrWhiteSpace();
            var greaterThan25 = new FirstNameCannotBeGreaterThanTwentyFive();
            return firstNameNotEmpty.Or(greaterThan25.Not()).IsSatisfiedBy(entity);
        }

        #endregion
    }
}