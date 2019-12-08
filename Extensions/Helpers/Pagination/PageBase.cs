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
                double totalPage = (double)TotalRecord / (double)PageSize;

                return (int)Math.Ceiling(totalPage);
            }
            set { TotalRecord = value; }
        }

        public int PageStartShow {
            get 
            {
                int result = 0;

                if(this.TotalPage - this.PageCurrent < 2)
                {
                    result = this.TotalPage - 5;
                }
                else
                {
                    result = this.PageCurrent - 2;
                }

                if(result <= 0 || this.TotalPage == 1)
                {
                    result = 1;
                }
                return result;
            }
            set { PageStartShow = value; } 
        }

        public int PageEndShow
        {
            get
            {
                int result = 0;

                if (this.PageCurrent < 2)
                {
                    result = 5;
                }
                else if(this.TotalPage - this.PageCurrent < 2)
                {
                    return this.TotalPage;
                }
                else
                {
                    result = this.PageCurrent - 2;
                }

                if (result <= 0 || this.TotalPage == 1)
                {
                    result = 1;
                }
                return result;
            }
            set { PageEndShow = value; }
        }
    }
}
