using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.InterfaceGeneric
{
    public interface Date
    {
        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
