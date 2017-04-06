﻿using System.Web.Mvc;
using MyCMS.Web.Infrastructure;

namespace MyCMS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ForceWww());
        }
    }
}