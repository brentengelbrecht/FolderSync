using System;
using Microsoft.Win32;

namespace FolderSync
{
    public class Configuration
    {
        private const String RegistryHome = @"Software\Zooloo\FolderSync";

        private String sourcePath;
        public String SourcePath 
        {
            get
            {
                return sourcePath;
            }
        }

        private String targetPath;
        public String TargetPath 
        {
            get
            {
                return targetPath;
            }
        }

        private ILogger logger;

        public Configuration(ILogger logger)
        {
            this.logger = logger;
            loadFromRegistry();
        }

        private void loadFromRegistry()
        {
            try
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (var sourceKey = hklm.OpenSubKey(RegistryHome))
                    {
                        if (sourceKey != null)
                        {
                            Object source = sourceKey.GetValue("SourcePath");
                            if (source != null)
                            {
                                sourcePath = source as String;
                            }

                            Object target = sourceKey.GetValue("TargetPath");
                            if (target != null)
                            {
                                targetPath = target as String;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogToError(e.Message);
            }
        }
    }
}
