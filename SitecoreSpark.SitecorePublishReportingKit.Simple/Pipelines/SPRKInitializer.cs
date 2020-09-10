using Sitecore.Data.Items;
using Sitecore.Pipelines;
using Sitecore.Publishing.Pipelines.PublishItem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SitecoreSpark.SPRK.Simple.Pipelines
{
    public class SPRKInitializer
    {
        private readonly string _logFolder;
        private readonly bool _enabled;

        public SPRKInitializer()
        {
            _logFolder = Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.LogFolder");
            _enabled = Sitecore.Configuration.Settings.GetBoolSetting("SitecoreSpark.SPRK.Enabled", false);
        }

        public void Process(PipelineArgs args)
        {
            // Only run if SPRK is enabled in config
            if (!_enabled)
                return;

            // Ensure the log folder exists before log output begins
            if (!Directory.Exists(_logFolder))
                Directory.CreateDirectory(_logFolder);
        }
    }
}