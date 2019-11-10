using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity
{
    public abstract class PrivateKey<T>
    {
        public T Id {get; set;}
    }
}
