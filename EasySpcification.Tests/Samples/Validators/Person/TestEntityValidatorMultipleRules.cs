using System;
using EasySpecification.Specification;
using EasySpecification.Validator;

namespace EasySpcification.Tests.Samples.Validators.Person
{
    public class TestEntityValidatorMultipleRules : IValidator<Entities.Person>
    {
        #region Implementation of IValidator<in Person>

        /// <exception cref="ArgumentNullException">Condition.</exception>
        public bool IsValid(Entities.Person entity)
        {
            var firstNameNotEmpty = new FirstNameCannotBeNullOrWhiteSpace();
            var greaterThan25 = new FirstNameCannotBeGreaterThanTwentyFive();
            return firstNameNotEmpty.Or(greaterThan25.Not()).IsSatisfiedBy(entity);
        }

        #endregion
    }
}