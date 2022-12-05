using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FolderSync
{
    public class FileActions
    {
        private String sourceFolder;
        private String targetFolder;

        public FileActions(Configuration configuration)
        {
            sourceFolder = configuration.SourcePath;
            targetFolder = configuration.TargetPath;
        }

        public void changed(String sourcePath)
        {
            String targetPath = getTargetPath(sourcePath, targetFolder);

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }

            File.Copy(sourcePath, targetPath);
        }

        public void created(String sourcePath)
        {
            changed(sourcePath);
        }

        public void deleted(String sourcePath)
        {
            String targetPath = getTargetPath(sourcePath, targetFolder);
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
        }

        public void renamed(String oldPath, String oldName, String newPath)
        {
            FileInfo source = new FileInfo(newPath);
            String fileToFind = targetFolder + "\\" + oldName;
            String fileTarget = targetFolder + "\\" + source.Name;

            if (File.Exists(fileToFind))
            {
                File.Move(fileToFind, fileTarget);
            }
        }

        private String getTargetPath(String sourcePath, String targetFolder)
        {
            FileInfo source = new FileInfo(sourcePath);
            return targetFolder + "\\" + source.Name;
        }
    }
}
