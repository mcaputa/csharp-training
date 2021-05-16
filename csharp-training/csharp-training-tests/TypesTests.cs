using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class TypesTests
    {
        [Test]
        public void FloatType_Precision_001()
        {
            //given
            float number = 0;
            float expectedValue = 0.9000001f;

            //when

            for (int i = 0; i < 9; i++)
            {
                number += 0.1f;
            }

            //then
            number.Should().Be(expectedValue); // float cannot represent all decimal fractions, so most of them are only aproximations e.g. 0.1

        }
    }
}
