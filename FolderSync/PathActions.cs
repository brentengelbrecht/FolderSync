using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FolderSync
{
    public class PathActions
    {
        private String sourceFolder;
        private String targetFolder;

        public PathActions(String sourceFolder, String targetFolder)
        {
            this.sourceFolder = sourceFolder;
            this.targetFolder = targetFolder;
        }

        public void created(String sourcePath)
        {
            String targetPath = getTargetPath(sourcePath, targetFolder);

            Directory.CreateDirectory(targetPath);
        }

        public void deleted(String sourcePath)
        {
            String targetPath = getTargetPath(sourcePath, targetFolder);
            if (Directory.Exists(targetPath))
            {
                Directory.Delete(targetPath, true);
            }
        }

        public void renamed(String oldPath, String oldName, String newPath)
        {
            FileInfo source = new FileInfo(newPath);
            String dirToFind = targetFolder + "\\" + oldName;
            String dirTarget = targetFolder + "\\" + source.Name;

            if (Directory.Exists(dirToFind))
            {
                Directory.Move(dirToFind, dirTarget);
            }
        }

        private String getTargetPath(String sourcePath, String targetFolder)
        {
            String newPart = sourcePath.Substring(sourceFolder.Length);
            if (newPart.Substring(0, 1) == "\\")
            {
                newPart = newPart.Remove(0, 1);
            }
            return targetFolder + "\\" + newPart;
        }
    }

}
