using EasySpecificationValidator.Specification;
using System;
using System.Threading.Tasks;

namespace EasySpecificationValidator.Tests.Samples.Specifications.Person.Async
{
    public class MustNotBeBornInSeptemberAsync : GenericSpecificationAsync<Entities.Person>
    {
        public override Func<Entities.Person, Task<bool>> Rule => person =>
        {
            Task.Delay(2000); //Pretend async delay.
            return Task.FromResult(person.BirthDate.Month != 9);
        };
    }
}
