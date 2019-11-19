using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.Extensions.Helpers.Pagination
{
    public abstract class PageBase
    {
        public int PageCurrent { get; set; }

        public int PageSize { get; set; }

        public int TotalRecord { get; set; }

        public int TotalPage
        {
            get
            {
                var totalPage = (double)(TotalRecord / PageSize);

                return (int)Math.Ceiling(totalPage);
            }
            set { TotalRecord = value; }
        }
    }
}
