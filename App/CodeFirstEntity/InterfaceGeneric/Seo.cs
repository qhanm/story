using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.CodeFirstEntity.InterfaceGeneric
{
    public interface Seo
    {
        string SeoTitle { get; set; }

        string SeoKeyWord { get; set; }

        string SeoDescription { get; set; }

        string SeoAlias { get; set; }
    }
}
