using EasySpecificationValidator.Tests.Samples.Entities;
using EasySpecificationValidator.Tests.Samples.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpecificationValidator.Tests.Samples
{
    [TestClass]
    public class SampleInUse
    {
        private readonly PersonValidatorAsync validator;

        public SampleInUse()
        {
            validator = new PersonValidatorAsync();
        }

        [TestMethod]
        public void IsUnder18_Fail()
        {
            var under18Person = new Person { Age = 17 };
        }
    }
}
