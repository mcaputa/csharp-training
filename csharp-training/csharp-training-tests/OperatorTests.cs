using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class OperatorTests
    {
        [Test]
        public void Operators_001()
        {
            //given
            int start = 1;

            //when
            var preIncrementation = ++start + 1;
            preIncrementation.Should().Be(3);

            start = 1;

            var postIncrementation = start++ + 1;
            postIncrementation.Should().Be(2);

            start = 1;
            var bitWiseOperator = false & ++start == 2;
            start.Should().Be(2);

            start = 1;
            var andOperator = false && ++start == 2;

            start.Should().Be(1);

            var bitWiseOrOperator = true | ++start == 2;
            start.Should().Be(2);

            start = 1;
            var orOperator = true || ++start == 2;

            start.Should().Be(1);
            var x = 1;
            var y = 2;

            int? max = x > y ? x : y; //conditional/tenary operator

            var nullCoalescingOperator = max ?? 0; // null coalescing operator

            x += 1; //compound assignment

            //then
        }
    }
}
