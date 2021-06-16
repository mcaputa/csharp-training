using csharp_training.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    class StructTests
    {
        [Test]
        public void Struct_001()
        {
            //given
            Point point = new Point() { X = 1, Y = 2 };
            Point point_2 = point;

            point.X += 1;

            point.X.Should().NotBe(point_2.X);
            object.ReferenceEquals(point, point_2).Should().BeFalse();

            CustomStruct cs = new CustomStruct();
            CustomStruct cs_2 = new CustomStruct();
            CustomStruct cs_3 = new CustomStruct();

            cs.Counter = new Counter();
            cs.Counter.AddNext();

            cs_2.Counter = cs.Counter;

            cs_3 = cs;

            cs_2.Counter.GetValue().Should().Be(1);
            object.ReferenceEquals(cs.Counter, cs_2.Counter).Should().BeTrue();
            object.ReferenceEquals(cs_3.Counter, cs.Counter).Should().BeTrue();


            //when

            //then
        }
    }
}
