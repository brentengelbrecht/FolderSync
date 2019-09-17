using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace FolderSync
{
    public class Configuration
    {
        private const String RegistryHome = "Software\\Zooloo\\FolderSync";

        private String sourcePath;
        private String targetPath;

        public Configuration()
        {
            loadFromRegistry();
        }

        public String getSourcePath()
        {
            return sourcePath;
        }

        public String getTargetPath()
        {
            return targetPath;
        }

        private void loadFromRegistry()
        {
            try
            {
                using (RegistryKey sourceKey = Registry.LocalMachine.OpenSubKey(RegistryHome))
                {
                    if (sourceKey != null)
                    {
                        Object source = sourceKey.GetValue("SourcePath");
                        if (source != null)
                        {
                            sourcePath = source as String;
                        }
                    }
                }

                using (RegistryKey targetKey = Registry.LocalMachine.OpenSubKey(RegistryHome))
                {
                    if (targetKey != null)
                    {
                        Object target = targetKey.GetValue("TargetPath");
                        if (target != null)
                        {
                            targetPath = target as String;
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
