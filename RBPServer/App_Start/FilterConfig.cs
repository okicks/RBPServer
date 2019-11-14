using System;
using System.Web;
using System.Web.Mvc;

namespace RBPServer
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters == null)
                throw new ArgumentNullException(nameof(filters));

            filters.Add(new HandleErrorAttribute());
        }
    }
}
