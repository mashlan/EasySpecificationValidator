using System;
using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Validator;

namespace EasySpcificationValidator.Tests.Samples.Validators.Person
{
    public class TestEntityValidatorMultipleRules : IValidator<Entities.Person>
    {
        #region Implementation of IValidator<in Person>

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public bool IsValid(Entities.Person entity)
        {
            var firstNameNotEmpty = new FirstNameCannotBeNullOrWhiteSpace();
            var notGreaterThan25 = new FirstNameCannotBeGreaterThanTwentyFive();
            var ageOver21 = new AgeMustBeOverTwentityOneOrOver();
            return ageOver21
                .And(firstNameNotEmpty
                    .And(notGreaterThan25))
                .IsSatisfiedBy(entity);
        }

        #endregion
    }
}