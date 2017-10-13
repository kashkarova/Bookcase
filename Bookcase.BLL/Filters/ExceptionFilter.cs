﻿using System.Web.Mvc;

namespace Bookcase.BLL.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled) return;
            filterContext.Result =
                new RedirectResult("~/Error/Index");
            filterContext.ExceptionHandled = true;
        }
    }
}