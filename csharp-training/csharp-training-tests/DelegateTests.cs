using csharp_training.Delegates;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class DelegateTests
    {
        [Test]
        public void MultiDelegate_001()
        {
            //given
            //when
            var test = new Predicate();
            var result = test.GetMultiPredicateResult();

            //then
            result.Should().BeTrue();
        }
    }
}
