using System;
using EasySpecification.Validator;

namespace EasySpcification.Tests.Samples.Entities
{
    public class Person : ICanValidate<Person>
    {
        public int Age { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}