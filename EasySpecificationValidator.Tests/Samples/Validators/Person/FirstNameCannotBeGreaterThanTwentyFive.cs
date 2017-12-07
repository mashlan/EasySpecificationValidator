using System;
using EasySpecificationValidator.Specification;

namespace EasySpecificationValidator.Tests.Samples.Validators.Person
{
    public class FirstNameCannotBeGreaterThanTwentyFive : GenericSpecification<Entities.Person>
    {
        #region Overrides of GenericSpecification<Person>

        public override Func<Entities.Person, bool> Rule => person => person.FirstName.Length <= 25;

        #endregion
    }
}