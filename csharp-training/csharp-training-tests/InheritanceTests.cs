using csharp_training.Inheritance;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class InheritanceTests
    {
        [Test]
        public void InterfaceInheritance_Test_001()
        {
            //given
            //when

            IAnotherInterface test = new CustomClassWithInterfaceInheritance();

            IBaseInterface baseInterface = (IBaseInterface)test;

            var Both = baseInterface as IBoth;

            //then
        }

        [Test]
        public void Covariance_Test_002()
        {
            //given            
            var cov = new Another();
            //when
            cov.Main();
            //then
        }

        [Test]
        public void Hidden_vs_Override_Test_003()
        {
            //given
            var derived = new Hidden();
            Dervied_Abstract baseObj = derived;

            //when
            var derived_resultForHidden = derived.CustomMethod();
            var base_resultForHidden = baseObj.CustomMethod(); //there is no replace. It return base result. 

            var derived_resultForOverride = derived.MethodToOverride();
            var base_resultForOverride = baseObj.MethodToOverride(); //it is the same like in derive

            var derived_resultForNew = derived.HideWarningByNewKeyword();
            var base_resultForNew = baseObj.HideWarningByNewKeyword();


            //then
            derived_resultForHidden.Should().NotBe(base_resultForHidden);
            derived_resultForHidden.Should().Be("hidden derived method");
            base_resultForHidden.Should().Be("Base hidden method");

            derived_resultForNew.Should().NotBe(base_resultForNew);
            derived_resultForNew.Should().Be("Derived - ignore warning");
            base_resultForNew.Should().Be("Base HideWarningByNewKeyword");


            derived_resultForOverride.Should().Be(base_resultForOverride);

        }
    }
}
