using System;
using EasySpecificationValidator.Specification;

namespace EasySpecificationValidator.Tests.Samples.Validators.Person
{
    public class FirstNameCannotBeNullOrWhiteSpace : GenericSpecification<Entities.Person>
    {
        #region Overrides of GenericSpecification<Person>

        public override Func<Entities.Person, bool> Rule => a => !string.IsNullOrWhiteSpace(a.FirstName);

        #endregion
    }
}