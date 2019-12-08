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
                new SelectListItem { Value = Status.DeActive.ToString(), Text = StatusConstant.Deactive},
                new SelectListItem { Value = Status.Active.ToString(), Text = StatusConstant.Active}
            };
        }

        public static List<SelectListItem> GetListCreate()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Status.DeActive.ToString(), Text = StatusConstant.Deactive},
                new SelectListItem { Value = Status.Active.ToString(), Text = StatusConstant.Active},
            };
        }

        public static List<SelectListItem> GetListStatus()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Status.DeActive.ToString(), Text = StatusConstant.Deactive},
                new SelectListItem { Value = Status.Active.ToString(), Text = StatusConstant.Active},
                new SelectListItem { Value = Status.All.ToString(), Text = StatusConstant.All},
            };
        }

        public static List<object> GetListStatusObject()
        {
            return new List<object>
            {
                new  { Value = Status.DeActive.ToString(), Text = StatusConstant.Deactive},
                new  { Value = Status.Active.ToString(), Text = StatusConstant.Active},
                new  { Value = Status.All.ToString(), Text = StatusConstant.All},
            };
        }

        public static List<object> GetListPaginate()
        {
            return new List<object>
            {
                new { Value = 10, Text = 10 },
                new { Value = 20, Text = 20 },
                new { Value = 50, Text = 50 }
            };
        }
    }
}
