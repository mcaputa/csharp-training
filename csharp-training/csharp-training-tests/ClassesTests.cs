using csharp_training.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class ClassesTests
    {
        [Test]
        public void InternalClass_1()
        {
            //given

            //var ok = new InternalClass(); - error

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void Static_2()
        {
            //given
            var firstCounter = new Counter();
            var secondCounter = new Counter();

            //when
            firstCounter.AddNext();
            firstCounter.AddNext();
            firstCounter.AddNext();

            secondCounter.AddNext();
            secondCounter.AddNext();

            //then
            firstCounter.GetValue().Should().Be(3);
            secondCounter.GetValue().Should().Be(2);
            Counter.TotalCount.Should().Be(5);
        }
    }
}
