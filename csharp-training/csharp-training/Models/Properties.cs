using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    class Properties
    {
        public string Name { get; }

        public int Age { get; } = 27;

        public Properties()
        {
            Name = "Maciek"; // only place where you can set value to read only property.
        }

        public void SetName(string name)
        {
            //Name = name; - error
        }
    }
}
