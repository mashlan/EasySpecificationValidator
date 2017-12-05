using System;
using System.Linq.Expressions;
using EasySpcification.Tests.Entities;
using EasySpecification.Specification;

namespace EasySpcification.Tests.Validators
{
    public class FirstNameCannotBeNullOrWhiteSpace : GenericSpecification<TestEntity>
    {
        public override Expression<Func<TestEntity, bool>> Rule => a => !string.IsNullOrWhiteSpace(a.FirstName);
    }
}