﻿using EasySpecificationValidator.Specification;
using System;
using System.Threading.Tasks;

namespace EasySpcificationValidator.Tests.Samples.Validators.Person.Async
{
    public class MustBeAtLeast18Async : GenericSpecificationAsync<Entities.Person>
    {
        public override Func<Entities.Person, Task<bool>> Rule => person =>
        {
            Task.Delay(2000); //Pretend async delay.
            return Task.FromResult(person.Age >= 18);
        };

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public async Task<bool> IsSatisfiedByAsync(Entities.Person entity)
        {
            return await Rule(entity);
        }
    }
}