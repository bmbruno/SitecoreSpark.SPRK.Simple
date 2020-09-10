using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSpark.SPRK.Simple.ViewModels
{
    public class DebugViewModel
    {
        public DebugViewModel() { }

        public bool Enabled;
        public bool DebugMode;
        public string LogFolder;
        public string LogPrefix;
        public int MaxLogBufferSize;
        public string SourceDatabase;
        public string TargetDatabase;
    }
}