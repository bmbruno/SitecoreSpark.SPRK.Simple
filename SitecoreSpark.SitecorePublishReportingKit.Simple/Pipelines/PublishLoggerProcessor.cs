using Sitecore.Data.Items;
using Sitecore.IO;
using Sitecore.Publishing.Pipelines.PublishItem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SitecoreSpark.SPRK.Simple.Pipelines
{
    public class PublishLoggerProcessor : PublishItemProcessor
    {
        private readonly string _logFolder;
        private readonly bool _enabled;
        private readonly string _logFilePrefix = "SPRK.log";

        public PublishLoggerProcessor()
        {
            _logFolder = Sitecore.Configuration.Settings.GetSetting("SitecoreSpark.SPRK.LogFolder");
            _enabled = Sitecore.Configuration.Settings.GetBoolSetting("SitecoreSpark.SPRK.Enabled", false);
        }

        public override void Process(PublishItemContext context)
        {
            if (context == null || context.Aborted)
                return;

            // Only run if SPRK is enabled in config
            if (!_enabled)
                return;

            string itemID = context.ItemId.ToString();
            string mode = context.PublishOptions.Mode.ToString();
            string operation = context.Result.Operation.ToString();
            string user = context.User.Name;
            string sourceDB = context.PublishOptions.SourceDatabase.Name;
            string targetDB = context.PublishOptions.TargetDatabase.Name;
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string logEntry = $"{itemID}|{mode}|{operation}|{user}|{sourceDB}|{targetDB}|{datetime}{Environment.NewLine}";

            try
            {
                string filePath = Path.Combine(_logFolder, String.Format("{0}.{1}.txt", _logFilePrefix, DateTime.Today.ToString("yyyyMMdd")));
                filePath = FileUtil.MapPath(filePath);

                File.AppendAllText(filePath, logEntry);
            }
            catch (Exception exc)
            {
                Sitecore.Diagnostics.Log.Error($"[SPRK] Exception logging publish for item ID {itemID}. Exception: {exc.ToString()}", this);
            }
        }
    }
}