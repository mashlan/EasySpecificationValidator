using System;
using EasySpecificationValidator.Specification;

namespace EasySpcificationValidator.Tests.Samples.Validators.Person
{
    public class AgeMustBeOverTwentityOneOrOver : GenericSpecification<Entities.Person>
    {
        #region Overrides of GenericSpecification<Person>

        /// <inheritdoc />
        public override Func<Entities.Person, bool> Rule => a => (a.Age >= 21);

        #endregion
    }
}