﻿using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SitecoreSpark.SPRK.Simple
{
    public class RegisterCustomRoute
    {
        public virtual void Process(PipelineArgs args)
        {
            Register();
        }

        public virtual void Register()
        {
            RouteTable.Routes.MapRoute("SitecoreSpark.SPRK.Simple.Index", "sitecore/sprk/{controller}/{action}/{id}", new { controller = "Report", action = "Index", id = UrlParameter.Optional });
        }
    }
}