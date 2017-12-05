using EasySpecification.Specification;
using EasySpecification.Validator;
using EasySpcification.Tests.Entities;

namespace EasySpcification.Tests.Validators
{
    public class TestEntityValidatorSingleRule: GenericValidator<TestEntity>
    {
        public override GenericSpecification<TestEntity> Specification
        {
            get => new FirstNameCannotBeNullOrWhiteSpace();
            set {}
        }
    }
}