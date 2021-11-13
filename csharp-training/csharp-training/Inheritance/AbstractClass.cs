using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Inheritance
{
    public abstract class AbstractClass : Base
    {
        public abstract int AbstractProperty { get; set; }

        public abstract void GetFoo();

        public virtual void Virtual()
        {

        }

        public void GetBoo()
        {
            //something
        }
    }

    public class Dervied_Abstract : AbstractClass
    {
        public override int AbstractProperty {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); }

        public override void GetFoo()
        {
            throw new NotImplementedException();
        }

        public void Virtual() // there is a warning
        {

        }

        public string CustomMethod()
        {
            return "Base hidden method";
        }

        public virtual string MethodToOverride()
        {
            return "Base to override";
        }
    }

    public interface IInterface : IBaseInterface, IBaseInterface2, IBoth
    {

    }

    public interface ICollision
    {
        public void Collision() { }
    }

    public class Derived_Collision : ICollision
    {
        public void Collision() // there is no warning like in abstract class
        {
            //test
        }
    }

    public class Hidden : Dervied_Abstract
    {
        public string CustomMethod() //hidden not override
        {
            return "hidden derived method";
        }

        public override string MethodToOverride()
        {
            return "override method";
        }
    }
}
