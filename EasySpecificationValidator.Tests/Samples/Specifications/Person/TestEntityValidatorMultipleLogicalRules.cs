using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Validator;

namespace EasySpecificationValidator.Tests.Samples.Validators.Person
{
    /// <summary>
    /// This validator will validate all rules even if first rule is invalid
    /// </summary>
    public class TestEntityValidatorMultipleLogicalRules: IValidator<Entities.Person>
    {
        /// <inheritdoc />
        public bool IsValid(Entities.Person entity)
        {
            var firstNameNotEmpty = new FirstNameCannotBeNullOrWhiteSpace();
            var notGreaterThan25 = new FirstNameCannotBeGreaterThanTwentyFive();
            var validEmail = new EmailMustBeValidEmailAddress();
            var age21OrOver = new AgeMustBeOverTwentityOneOrOver();

            return firstNameNotEmpty
                .LogicalAnd(notGreaterThan25
                    .LogicalAnd(validEmail
                        .LogicalAnd(age21OrOver)))
                .IsSatisfiedBy(entity);
        }

    }
}