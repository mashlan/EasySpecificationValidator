using System.Threading.Tasks;
using EasySpecificationValidator.Specification;
using EasySpecificationValidator.Tests.Samples.Entities;
using EasySpecificationValidator.Tests.Samples.Specifications.Person.Async;
using EasySpecificationValidator.Tests.Samples.Validators.Person.Async;
using EasySpecificationValidator.Validator;

namespace EasySpecificationValidator.Tests.Samples.Validator
{
    public class PersonValidatorAsync : IValidatorAsync<Person>
    {
        #region Implementation of IValidatorAsync<in Person>

        public async Task<bool> IsValidAsync(Person entity)
        {
            var mustBeAtLeast18 = new MustBeAtLeast18Async();
            var mustNotBeBornInSeptember = new MustNotBeBornInSeptemberAsync();

            return await mustBeAtLeast18.AndAsync(mustNotBeBornInSeptember).IsSatisfiedByAsync(entity);
        }

        #endregion
    }
}
