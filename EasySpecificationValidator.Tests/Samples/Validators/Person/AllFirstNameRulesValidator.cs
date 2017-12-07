using System;
using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Validator;

namespace EasySpecificationValidator.Tests.Samples.Validators.Person
{
    public class AllFirstNameRulesValidator : IValidator<Entities.Person>
    {
        #region Implementation of IValidator<in Person>

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public bool IsValid(Entities.Person entity)
        {
            var firstNameNotEmpty = new FirstNameCannotBeNullOrWhiteSpace();
            var notGreaterThanTwentyFive = new FirstNameCannotBeGreaterThanTwentyFive();
            return firstNameNotEmpty.Or(notGreaterThanTwentyFive).IsSatisfiedBy(entity);
        }

        #endregion
    }
}