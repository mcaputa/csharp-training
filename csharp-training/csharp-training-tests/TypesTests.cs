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

        [Test]
        public void StringType_004()
        {
            //given
            int iterationNumber = 100_000;
            string stringType = string.Empty;
            var stopwatch = new Stopwatch();

            StringBuilder stringBuilder = new StringBuilder();

            //when
            #region string vs string builder
            stopwatch.Start();
            for (int i = 0; i < iterationNumber; i++)
            {
                stringType += "test";
            }
            stopwatch.Stop();
            Trace.WriteLine($"string: {stopwatch.ElapsedMilliseconds}, {stringType}");

            stopwatch.Restart();
            for (int i = 0; i < iterationNumber; i++)
            {
                stringBuilder.Append("test");
            }

            stopwatch.Stop();            
            Trace.WriteLine($"string builder: {stopwatch.ElapsedMilliseconds}, {stringBuilder}");
            #endregion

            Trace.WriteLine($"{iterationNumber:f1}");

            var message = FormattableString.Invariant($"test");

            var verbatimStringLiterals = @" test 
                multiline";

            var verbatimAndInterpolation = $@"test
                multiline 
                {iterationNumber}";

            var text = @"Hello ""World""";
            Trace.WriteLine(text);


            //then
            Assert.Pass();
        }

        [Test]
        public void Tuples_005()
        {
            //given
            (int X, int Y) point = (1, 2);

            var point_2 = (X: 4, Y: 8);

            (int X1, int Y2) point_3 = point_2;

            (int, int) test = (1, 1);

            (double, float) conversion = (2d, 3f);

            test = ((int, int))conversion;
            conversion = test;

            Trace.WriteLine(test != conversion);

            (string Name, int Age) person = ("Maciek", 27);
            string name;
            int age;

            (name, age) = person; //deconstruction
            Trace.WriteLine($"{name}, {age}");

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void Dynamic_006()
        {
            //given
            dynamic variable = "ok";
            variable = 10;

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void Object_007()
        {
            //given
            object variable = "ok";
            variable = 10;

            //when
            //then
            Assert.Pass();
        }

    }
}
