using System;
using System.Net.Mail;
using EasySpecificationValidator.Specification;

namespace EasySpcificationValidator.Tests.Samples.Validators.Person
{
    public class EmailMustBeValidEmailAddress: GenericSpecification<Entities.Person>
    {
        #region Overrides of GenericSpecification<Person>

        /// <inheritdoc />
        public override Func<Entities.Person, bool> Rule => a =>
        {
            try
            {
                var mailAddress = new MailAddress(a.Email);
                return true;
            }
            catch
            {
                return false;
            }
        };

        #endregion
    }
}