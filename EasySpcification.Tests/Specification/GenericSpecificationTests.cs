﻿using System;
using System.Collections.Generic;
using System.Text;
using EasySpecification.Specification;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasySpcification.Tests.Specification
{
    public class GenericSpecificationTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var genericSpecification = new MockGenericSpecification<string>();

                genericSpecification.Should().NotBeNull();
                genericSpecification.Should().BeAssignableTo<ISpecification<string>>();
                genericSpecification.Should().BeAssignableTo<GenericSpecification<string>>();
                genericSpecification.Should().BeOfType<MockGenericSpecification<string>>();
            }
        }

        internal class MockGenericSpecification<TEntity> : GenericSpecification<TEntity>
        {
            #region Overrides of GenericSpecification<TEntity>

            public override Func<TEntity, bool> Rule { get; }

            #endregion
        }
    }
}
