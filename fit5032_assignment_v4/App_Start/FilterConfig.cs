﻿using System.Web;
using System.Web.Mvc;

namespace fit5032_assignment_v4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
