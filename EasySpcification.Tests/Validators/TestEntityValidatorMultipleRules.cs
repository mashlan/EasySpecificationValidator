using EasySpcification.Tests.Entities;
using EasySpecification.Specification;
using EasySpecification.Validator;

namespace EasySpcification.Tests.Validators
{
    public class TestEntityValidatorMultipleRules : GenericValidator<TestEntity>
    {
        public override GenericSpecification<TestEntity> Specification
        {
            get => new FirstNameCannotBeNullOrWhiteSpace();
            set {}
        }


        public override bool IsValid(TestEntity entity)
        {
            var greaterThan25 = new FirstNameCannotBeGreaterThanTwentyFive();
            return Specification.Or(greaterThan25.Not()).IsSatisfiedBy(entity);
        }
    }
}