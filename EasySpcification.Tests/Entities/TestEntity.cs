using System;
using EasySpecification.Validator;

namespace EasySpcification.Tests.Entities
{
    public class TestEntity : ICanValidate<TestEntity>
    {
        public int Age { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}