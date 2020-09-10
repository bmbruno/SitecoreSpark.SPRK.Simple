using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSpark.SPRK.Simple.ViewModels
{
    public class LogIndexViewModel
    {
        public List<LogItemViewModel> LogItems { get; set; }

        public LogIndexViewModel()
        {
            LogItems = new List<LogItemViewModel>();
        }
    }
}