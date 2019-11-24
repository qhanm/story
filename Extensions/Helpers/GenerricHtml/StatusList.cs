using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using story.App.CodeFirstEntity.Constant;
using story.Extensions.Constants;

namespace story.Extensions.Helpers.GenerricHtml
{
    public static class StatusList
    {
        public static List<SelectListItem> GetList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Status.Active.ToString(), Text = StatusConstant.Active},
                new SelectListItem { Value = Status.DeActive.ToString(), Text = StatusConstant.Deactive}
            };
        }
    }
}
