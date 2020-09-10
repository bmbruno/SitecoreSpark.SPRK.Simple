using System;
using System.Web.Mvc;
using SitecoreSpark.SPRK.Simple.ViewModels;

namespace SitecoreSpark.SPRK.Simple.Controllers
{
    [Authorize]
    public class DebugController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Convert.ToBoolean(Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.DebugMode")) != true)
                filterContext.Result = Redirect("/sitecore");
        }

        public DebugController() { }
        
        public ActionResult Index()
        {
            DebugViewModel viewModel = GetDebugViewModel();            
            return View("~/Views/SPRK/Debug/Index.cshtml", viewModel);
        }

        private DebugViewModel GetDebugViewModel()
        {
            DebugViewModel viewModel = new DebugViewModel();

            viewModel.Enabled = Convert.ToBoolean(Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.Enabled"));
            viewModel.DebugMode = Convert.ToBoolean(Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.DebugMode"));
            viewModel.LogFolder = Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.LogFolder");
            viewModel.SourceDatabase = Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.SourceDatabase");
            viewModel.TargetDatabase = Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.TargetDatabase");

            return viewModel;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}