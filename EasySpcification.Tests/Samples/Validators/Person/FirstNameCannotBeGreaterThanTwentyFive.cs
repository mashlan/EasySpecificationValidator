using System;
using EasySpecification.Specification;

namespace EasySpcification.Tests.Samples.Validators.Person
{
    public class FirstNameCannotBeGreaterThanTwentyFive : GenericSpecification<Entities.Person>
    {
        #region Overrides of GenericSpecification<Person>

        public override Func<Entities.Person, bool> Rule => a => !(a.FirstName.Length > 25);

        #endregion
    }
}