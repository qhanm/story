using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace story.Extensions.Helpers.Pagination
{
    public class PageResult<T> : PageBase where T:class
    {
        public IList<T> Results { get; set; }

        public PageResult()
        {
            Results = new List<T>();
        }
    }
}
