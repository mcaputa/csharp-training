using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
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

        [Test]
        public void NumberShortcuts_002()
        {
            //given
            var largeInt = 1_000_000_000;
            var floatType = 1.00f;
            var doubleType = 1.00D;
            var decimalType = 10m;
            var exponential = 1.5E2;
            var exponentialDecimal = 1.5E2M;

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void NumberConversions_003()
        {
            //given
            int i = 42;
            double di = i; //42.00
            float f = 3;
            Trace.WriteLine(i / 5);
            Trace.WriteLine(di / 5);
            Trace.WriteLine(i / 5.0);
            var result = di / f;
            //int errorDoubleConversionToInt = di; 
            int explicityConversionDoubleToInt = (int)di;
            //int error = i / 1.0;
            //int overflow = (int)3_000_000_001f; - error   

            int minValue = unchecked(int.MaxValue + 1);

            BigInteger bigInteger = int.MaxValue;
            bigInteger += 1;



            //when
            //then
            minValue.Should().Be(int.MinValue);
            bigInteger.Should().Be(2_147_483_648);
            Assert.Pass();
        }
    }
}
