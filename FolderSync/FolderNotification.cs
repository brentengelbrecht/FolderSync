using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FolderSync
{
    public class FolderNotification
    {
        private FileActions fileActions;
        private PathActions pathActions;

        public FolderNotification(PathActions pathActions, FileActions fileActions)
        {
            this.pathActions = pathActions;
            this.fileActions = fileActions;
        }

        public void handleChanged(object sender, FileSystemEventArgs e)
        {
            if (!isDirectory(e.FullPath))
            {
                fileActions.changed(e.FullPath);
            }
        }

        public void handleCreated(object sender, FileSystemEventArgs e)
        {
            if (isDirectory(e.FullPath))
            {
                pathActions.created(e.FullPath);
            }
            else
            {
                fileActions.created(e.FullPath);
            }
        }

        public void handleDeleted(object sender, FileSystemEventArgs e)
        {
            pathActions.deleted(e.FullPath);
            fileActions.deleted(e.FullPath);
        }

        public void handleRenamed(object sender, RenamedEventArgs e)
        {
            if (isDirectory(e.FullPath))
            {
                pathActions.renamed(e.OldFullPath, e.OldName, e.FullPath);
            }
            else
            { 
                fileActions.renamed(e.OldFullPath, e.OldName, e.FullPath);
            }
        }

        private Boolean isDirectory(String fullPath)
        {
            FileAttributes attributes = File.GetAttributes(fullPath);
            return attributes.HasFlag(FileAttributes.Directory);
        }
    }
}
