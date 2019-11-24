using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace story.Areas.Admin.Page
{
    public class PageForbiddenViewResult : ViewResult
    {
        public PageForbiddenViewResult(string viewName)
        {
            ViewName = viewName;
            StatusCode = (int)HttpStatusCode.Forbidden;
        }
    }
}