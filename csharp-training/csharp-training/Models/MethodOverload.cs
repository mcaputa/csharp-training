using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class MethodOverload
    { 
        public bool Blame() // could be instead default parameters. Quiet usefull when writing library
        {
            return Blame("any problem");
        }

        public bool Blame(string problem)
        {
            return Blame(problem, "any perception");
        }

        public bool Blame(string problem, string perception)
        {
            return true;
        }
    }
}
