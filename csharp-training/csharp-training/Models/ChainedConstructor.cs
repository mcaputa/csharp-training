using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class ChainedConstructor
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ChainedConstructor() : this(null)    
        {

        }

        public ChainedConstructor(string name) : this(name, 1)
        {

        }

        public ChainedConstructor(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
